import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { APP_KEY, APP_SECRET } from 'src/app/kinvey.tokens';
import { AuthService } from '../services/auth.service';
import { tap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService,
        private toastr: ToastrService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.url.endsWith(`${APP_KEY}/login`) || req.url.endsWith(`user/${APP_KEY}`)) {
            req = req.clone({
                setHeaders: {
                    'Authorization': `Basic ${btoa(`${APP_KEY}:${APP_SECRET}`)}`,
                    'Content-Type': 'application/json'
                }
            })
        }
        else {
            req = req.clone({
                setHeaders: {
                    'Authorization': `Kinvey ${localStorage.getItem('token')}`
                }
            })
        }

        return next.handle(req)
            .pipe(tap((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse && req.url.endsWith('login')) {
                    this.toastr.success('Logged in successfully', 'Success!');
                    this.authService.saveUserInfo(event.body);
                }
            }));
    }
}
