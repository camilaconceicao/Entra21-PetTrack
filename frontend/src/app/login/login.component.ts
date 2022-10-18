import { Router } from '@angular/router';
import { AuthService } from './auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public user: any = {
    email: '',
    senha: '',
  };

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {}

  logar() {
    this.authService.login(this.user).subscribe((res: any) => {
      this.auth(res);
    });
  }

  auth(is_auth: boolean) {
    if (is_auth) {
      this.authService.autenticar();
      this.success();
    } else {
      this.error();
    }
  }

  success() {
    this.router.navigate(['']);
  }
  error() {
    alert('Erro ao realizar o login');
  }
}
