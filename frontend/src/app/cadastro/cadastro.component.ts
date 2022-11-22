import { Component } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent{
  loginFormGroup: FormGroup;
  UserRegisterFormGroup: FormGroup;
  loading: boolean;
  submitLogin: boolean;
  submitRegister: boolean;

  constructor(private formBuilder: FormBuilder,private response: BaseService,private toastr: ToastrService,
    private router: Router) {
    this.loading = false;
    this.submitLogin = false;
    this.submitRegister = false;

    this.loginFormGroup = this.formBuilder.group({
        emailLogin: ['', Validators.required],
        senhaLogin: ['', Validators.required]
    });

    this.UserRegisterFormGroup = this.formBuilder.group({
      email: ['', [Validators.required,Validators.email]],
      nome: ['', Validators.required],
      CPF: ['', [Validators.required,Validators.minLength(11)]],
      senha: ['', [Validators.required]],
    });
  }

  RegisterUsuario = (form:FormGroup) =>{
    if(this.UserRegisterFormGroup.invalid){
      this.submitRegister = true;
      return;
    }

    this.loading = true;
    this.response.Post("Usuario","CadastroInicial",form.value).subscribe(
      (response: any) =>{        
        if(response.sucesso){
          window.localStorage.setItem('NomeUsuario',response.data.nome);
          window.localStorage.setItem('IdUsuario',response.data.idUsuario);
          window.localStorage.setItem('Token',response.data.sessionKey.acess_token);
          this.toastr.success('<small> Seja bem vindo <br>' + response.data.nome, 'Mensagem:');   
          this.router.navigate(['/', 'main'])        
        }else
        {
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem');
        }
        this.loading = false;
      }
    );
  }
    
  Login = (form:FormGroup) =>{
    if(this.loginFormGroup.invalid){
      this.submitLogin = true;
      return;
    }

    this.loading = true;
    this.response.Post("Auth","Login",form.value).subscribe(
      (response: any) =>{        
        if(response.sucesso){
          window.localStorage.setItem('NomeUsuario',response.data.nome);
          window.localStorage.setItem('IdUsuario',response.data.idUsuario);
          window.localStorage.setItem('Token',response.data.sessionKey.acess_token);
          this.toastr.success('<small>' + 'Seja bem vindo de volta: <br>' + response.data.nome + '<small>', 'Mensagem:');   
          this.router.navigate(['/', 'main'])
        }
        else
        {
          this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }


  //Campo Senha
  ActiveEyePasswordLogin: boolean = false;
  ActiveEyePasswordRegister: boolean = false;

  EyePasswordRegister = (): void => {
    this.ActiveEyePasswordRegister = !this.ActiveEyePasswordRegister;
  };

  EyePasswordLogin = (): void => {
    this.ActiveEyePasswordLogin = !this.ActiveEyePasswordLogin;
  };
}
