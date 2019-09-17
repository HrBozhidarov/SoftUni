import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
    selector: 'app-comment-info',
    templateUrl: './comment-info.component.html',
    styleUrls: ['./comment-info.component.css']
})
export class CommentInfoComponent {
    @Input() commentInfo;
    @Input() post;
    @Output() commentId = new EventEmitter<string>();

    deleteComment(id: string) {
        this.commentId.emit(id);
    }

    isAuthor() {
        return this.commentInfo['_acl']['creator'] === localStorage.getItem('userId');
    }
}
