import { NgModule } from '@angular/core';
import { CommentService } from './services/comment.service';
import { PostService } from './services/post.service';
import { AuthService } from './services/auth.service';
import { AuthenticationInterceptor } from './interceptors/authentication.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { PostResolver } from './resolvers/post.resolver';
import { CommentResolver } from './resolvers/comment.resolver';
import { RankResolver } from './resolvers/rank.resolver';
import { PostEditResolver } from './resolvers/post-edit.resolver';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
    declarations: [],
    imports: [
        HttpClientModule
    ],
    exports: [],
    providers: [
        CommentService,
        PostService,
        AuthService,
        { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        PostResolver,
        CommentResolver,
        RankResolver,
        PostEditResolver,
        AuthGuard
    ]
})
export class CoreModule {

}