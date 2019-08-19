import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptorService implements HttpInterceptor {
  constructor(private toastrService: ToastrService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let reqClone = req.clone();

    return next.handle(reqClone)
      .pipe(
        catchError(( error: HttpErrorResponse ) => {
          let errorMessage = error.error.message;
          this.toastrService.error(errorMessage);

          return throwError(errorMessage); 
        })
      );
  }
}
