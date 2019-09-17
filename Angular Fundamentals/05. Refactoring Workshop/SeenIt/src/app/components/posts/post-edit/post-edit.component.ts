import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../../core/services/post.service';
import { PostModel } from '../../shared/models/postModel';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.css']
})
export class PostEditComponent implements OnInit, OnDestroy {
  @ViewChild('f') editPostForm: NgForm;
  subscription: Subscription;
  post: PostModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService
  ) { }

  ngOnInit() {
    this.post = this.route.snapshot.data['editPost'];
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  editPost() {
    const body = this.editPostForm.value;
    body['author'] = localStorage.getItem('username');

    this.subscription = this.postService.editPost(body, this.post['_id'])
      .subscribe(() => {
        this.router.navigate(['/posts']);
      })
  }
}
