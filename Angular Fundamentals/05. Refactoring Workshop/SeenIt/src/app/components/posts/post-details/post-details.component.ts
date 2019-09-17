import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../../core/services/post.service';
import { CommentService } from '../../../core/services/comment.service';
import { PostModel } from '../../shared/models/postModel';
import { CommentModel } from '../../shared/models/commentModel';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {
  post: PostModel;
  comments: CommentModel[];
  rank: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService,
    private commentService: CommentService
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.rank = this.route.snapshot.data['rank'].map(x => x._id).indexOf(id);
    this.post = this.route.snapshot.data['post'];
    this.comments = this.route.snapshot.data['comment'];
  }

  loadComments() {
    this.commentService.getAllForPost(this.post['_id'])
      .subscribe((data: CommentModel[]) => {
        this.comments = data;
      });
  }

  deleteComment(id: string) {
    this.commentService.deleteComment(id)
      .subscribe(() => {
        this.loadComments();
      })
  }

  postComment(createCommentForm) {
    const body = createCommentForm.value;
    body['postId'] = this.post['_id'];
    body['author'] = localStorage.getItem('username');

    this.commentService
      .postComment(createCommentForm.value)
      .subscribe(() => {
        createCommentForm.reset();
        this.loadComments();
      })
  }

  isAuthor() {
    return this.post['_acl']['creator'] === localStorage.getItem('userId');
  }

  deletePost(id: string) {
    this.postService.deletePost(id)
      .subscribe(() => {
        this.router.navigate(['/posts']);
      })
  }
}
