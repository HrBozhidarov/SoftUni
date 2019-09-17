import { NgModule } from "@angular/core";
import { PostListComponent } from './post-list/post-list.component';
import { PostCreateComponent } from './post-create/post-create.component';
import { PostEditComponent } from './post-edit/post-edit.component';
import { PostDetailsComponent } from './post-details/post-details.component';
import { PostInfoComponent } from './post-info/post-info.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CommentModule } from '../comments/comment.module';
import { PostRouterModule } from './post-routing';

@NgModule({
    declarations: [
        PostListComponent,
        PostCreateComponent,
        PostEditComponent,
        PostDetailsComponent,
        PostInfoComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        PostRouterModule,
        CommentModule
    ],
    exports: [],
    providers: []
})
export class PostModule {
    
}