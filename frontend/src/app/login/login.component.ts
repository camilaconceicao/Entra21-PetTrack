import { Component } from '@angular/core';
import { BaseService } from 'src/service/base-service.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuarioResponse } from 'src/objects/Usuario/UsuarioResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})

export class LoginComponent{
  //Variaveis operacionais
  submitLogin: boolean = false;
  loading: boolean = false;
  hide = true;

  //Formulario
  LoginFormGroup = this._formBuilder.group({
    emailLogin: ['', Validators.required],
    senhaLogin: ['', Validators.required]
  });

  constructor(private _formBuilder: FormBuilder,private response: BaseService,
    private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
  }

  Login = (form:FormGroup) =>{
    this.submitLogin = true;

    if(this.LoginFormGroup.invalid){
      this.submitLogin = true;
      return;
    }

    this.loading = true;
    this.response.Post("Auth","Login",form.value).subscribe(
      (response: UsuarioResponse) =>{        
        if(response.sucesso){
          window.localStorage.setItem('NomeUsuario',response.data.nome);
          window.localStorage.setItem('IdUsuario',response.data.idUsuario);
          window.localStorage.setItem('Email',response.data.email);
          window.localStorage.setItem('CPF',response.data.cpf);
          window.localStorage.setItem('Token',response.data.sessionKey.acess_token);
          this.response.UsuarioLogado(true);
          this.toastr.success(response.mensagem, 'Mensagem:');
          this.router.navigateByUrl('/')
        }else{
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
