import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { PostModel } from '../../shared/models/postModel';

@Component({
    selector: 'app-post-info',
    templateUrl: './post-info.component.html',
    styleUrls: ['./post-info.component.css']
})
export class PostInfoComponent implements OnInit {
    @Input() post: PostModel;
    @Input() rank: number;
    @Output() postId = new EventEmitter<string>();

    constructor() { }

    ngOnInit(): void {}

    isAuthor(post: PostModel) {
        return this.post['_acl']['creator'] === localStorage.getItem('userId');
    }

    deletePost(id: string) {
        this.postId.emit(id);
    }
}
