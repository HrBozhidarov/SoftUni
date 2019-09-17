import { Injectable } from '@angular/core'
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { CommentService } from '../services/comment.service';

@Injectable()
export class CommentResolver implements Resolve<any> {
    constructor(private commentService: CommentService) {

    }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const id = route.params['id'];

        return this.commentService.getAllForPost(id);
    }
}