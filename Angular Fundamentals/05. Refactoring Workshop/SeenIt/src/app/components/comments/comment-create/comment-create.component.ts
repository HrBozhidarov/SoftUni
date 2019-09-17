import { Component, ViewChild, Input, Output, EventEmitter } from "@angular/core";
import { NgForm } from '@angular/forms';
import { PostModel } from '../../shared/models/postModel';

@Component({
    selector: 'app-comment-create',
    templateUrl: './comment-create.component.html',
    styleUrls: ['./comment-create.component.css']
})
export class CommentCreateComponent {
    @ViewChild('f') createCommentForm: NgForm;
    @Input() postModel: PostModel;
    @Output() form = new EventEmitter<NgForm>();

    postComment() {
        this.form.emit(this.createCommentForm);
    }
}