import { Component } from '@angular/core';
import { BaseService } from 'src/service/base-service.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent{
  loginFormGroup: FormGroup;
  submitLogin: boolean = false;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private response: BaseService,
    ) {

      this.loginFormGroup = this.formBuilder.group({
        emailLogin: ['', Validators.required],
        senhaLogin: ['', Validators.required]
      });
  }

  Login = (form:any) =>{
    this.submitLogin = true;

    if(this.loginFormGroup.invalid){
      this.submitLogin = true;
      return;
    }

    this.loading = true;
    this.response.Post("Auth","Login",form.value).subscribe(
      (response: any) =>{        
        if(response.sucesso){
          window.localStorage.setItem('NomeUsuario',response.data.nome);
          window.localStorage.setItem('Token',response.data.sessionKey.acess_token);
          // this.toastr.success('<small>' + 'Seja bem vindo ' + response.data.nome + '<small>', 'Mensagem:');   
          // this.router.navigate(['/', 'main'])
        }else{
          // this.toastr.error('<small>' + response.mensagem + '</small>', 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
