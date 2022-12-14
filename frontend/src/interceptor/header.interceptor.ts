import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap, throwError } from "rxjs";
import { ToastrService } from 'ngx-toastr';
import { Router } from "@angular/router";
import { BaseService } from "src/service/base-service.component";

@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {
  token!: string | null;

  constructor(private toastr: ToastrService,private router: Router,private response:BaseService){}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.token = window.localStorage.getItem('Token');

    req = req.clone({
        setHeaders: { Authorization: `Bearer ${this.token}`}
    });

    return next.handle(req).pipe(tap({
      error: err => {
        if (err instanceof HttpErrorResponse) {
          debugger
          if (err.status == 403)
          {
            this.toastr.warning('<small>Sua sessão expirou!</small>');
              window.localStorage.clear();
              this.response.UsuarioLogado(false);
              this.router.navigateByUrl('/pag-401');
            }else{
              throwError(() => new Error(err.message))
              this.router.navigateByUrl('/pag-500');
            }

        }
      },
    }));
  };
};

