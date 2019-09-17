import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, UrlSegment, Router } from '@angular/router';
import { PostService } from '../../../core/services/post.service';
import { PostModel } from '../../shared/models/postModel';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit, OnDestroy {
  $allPosts: Observable<PostModel[]>;
  subscription: Subscription;

  constructor(
    private postService: PostService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.url.subscribe((segmentArr: UrlSegment[]) => {
      if (segmentArr.length === 0) {
        this.$allPosts = this.postService.getAll();
      } else if (segmentArr.length === 1) {
        this.$allPosts = this.postService.getUserPosts();
      }
    })
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  onDeletePost(id: string) {
    this.subscription = this.postService.deletePost(id)
      .subscribe(() => {
        this.$allPosts = this.postService.getAll();
      })
  }
}
