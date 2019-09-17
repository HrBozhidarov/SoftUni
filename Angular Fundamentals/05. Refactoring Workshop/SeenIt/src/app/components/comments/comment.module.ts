import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommentInfoComponent } from '../comments/commnet-info/comment-info.component';
import { CommentCreateComponent } from '../comments/comment-create/comment-create.component';

@NgModule({
    declarations: [
        CommentCreateComponent,
        CommentInfoComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule
    ],
    exports: [
        CommentCreateComponent,
        CommentInfoComponent,
    ],
    providers: []
})
export class CommentModule {
    
}