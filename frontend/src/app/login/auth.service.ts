import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate{

  constructor(
    public http:HttpClient,
    public router:Router
  ) { }

  public login(user:any) {
    const http_options: any = {
      Headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*'
      }),
    };

    let formData = new FormData();
    formData.append('login',user.email)
    formData.append('senha',user.senha);

    return this.http.post(
      'http://localhost:8080/auth',
      {
        login :user.email,
        senha :user.senha,
      },
      http_options
    );
  }  

  autenticar(){
    localStorage.setItem('is_auth','true');
  }

  canActivate(
    route: ActivatedRouteSnapshot, 
    state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {
    
    let is_auth = JSON.parse(String(localStorage.getItem('is_auth')));
    console.log(is_auth);
    if (is_auth){
      this.router.navigate(['/dashboard']);
      return true;
    }else{
      this.router.navigate(['/login']);
      return false;
    }
  }  
}