import { Routes, RouterModule } from "@angular/router";
import { PostListComponent } from './post-list/post-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { PostEditComponent } from './post-edit/post-edit.component';
import { PostEditResolver } from 'src/app/core/resolvers/post-edit.resolver';
import { PostDetailsComponent } from './post-details/post-details.component';
import { PostResolver } from 'src/app/core/resolvers/post.resolver';
import { CommentResolver } from 'src/app/core/resolvers/comment.resolver';
import { RankResolver } from 'src/app/core/resolvers/rank.resolver';
import { NgModule } from '@angular/core';

const routes: Routes = [
    { path: '', component: PostListComponent },
    { path: 'user', component: PostListComponent },
    { path: 'create', component: PostCreateComponent },
    {
        path: 'edit/:id', component: PostEditComponent,
        resolve: {
            editPost: PostEditResolver
        }
    },
    {
        path: 'details/:id', component: PostDetailsComponent,
        resolve: {
            post: PostResolver,
            comment: CommentResolver,
            rank: RankResolver
        }
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class PostRouterModule {
    
}