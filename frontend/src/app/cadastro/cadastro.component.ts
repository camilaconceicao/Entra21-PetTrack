import { Component,EventEmitter, Output } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BaseService } from 'src/service/base-service.component';
import { Endereco } from 'src/objects/Endereco/Endereco';
import { ValidateSenha } from 'src/validators/validators-form';
import { UsuarioRequest } from 'src/objects/Usuario/UsuarioRequest';
import { UsuarioResponse } from 'src/objects/Usuario/UsuarioResponse';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: {showError: true},
    },
  ],
})

export class CadastroComponent{
  //Variaveis operacionais
  loading: boolean = false;
  submit: boolean = false;
  hide = true;
  request!: UsuarioRequest; 

  //Formulário
  PerfilFormGroup = this._formBuilder.group({
    nome: [undefined, Validators.required],
    telefone: [undefined, [Validators.required,Validators.minLength(11)]],
    cpf: [undefined, [Validators.required,Validators.minLength(11)]],
    dataNascimento: [undefined, [Validators.required,Validators.minLength(8)]],
  });

  EnderecoFormGroup = this._formBuilder.group({
    cep: ['', Validators.minLength(8)],
    cidade: [''],
    bairro: [''],
    rua: [''],
    numero: [undefined]
  });

  AcessoFormGroup = this._formBuilder.group({
    senha: ['', [Validators.required,ValidateSenha]],
    email: ['',[Validators.required,Validators.email]],
    termo: [false]
  });

  constructor(private _formBuilder: FormBuilder,private response: BaseService,
    private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
  }

  PesquisarEndereco = () => {
    let cepValue = this.EnderecoFormGroup.get('cep'); 
    this.loading = true;

    if(cepValue?.invalid){
      this.loading = false;
      this.toastr.error('<small>Preencha o campo cep corretamente!</small>', 'Mensagem:');
      return;
    }

    this.response.Get("Utils","ConsultarEnderecoCep/" + cepValue?.value).subscribe(
      (response: Endereco) =>{        
        if(response.sucesso){
          this.EnderecoFormGroup.get('cidade')?.setValue(response.data.cidade);
          this.EnderecoFormGroup.get('rua')?.setValue(response.data.rua);
          this.EnderecoFormGroup.get('bairro')?.setValue(response.data.bairro);
        }
        else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  };

  Salvar = () =>{
    this.submit = true;
    this.loading = true;

    if(this.PerfilFormGroup.invalid || this.AcessoFormGroup.invalid || this.EnderecoFormGroup.invalid){
      this.loading = false;
      this.toastr.error('<small>Preencha os campos corretamente no formulário!</small>', 'Mensagem:');
      return;
    }

    if(this.AcessoFormGroup.get('termo')?.value == false){
      this.loading = false;
      this.toastr.error('<small>Para prosseguir com o cadastro aceite os termos!</small>', 'Mensagem:');
      return;
    }

    this.request = {
      Nome: this.PerfilFormGroup.get('nome')?.value,
      Telefone: this.PerfilFormGroup.get('telefone')?.value,
      Cpf: this.PerfilFormGroup.get('cpf')?.value,
      DataNascimento: this.PerfilFormGroup.get('dataNascimento')?.value,
      Cep: this.EnderecoFormGroup.get('cep')?.value,
      Cidade: this.EnderecoFormGroup.get('cidade')?.value,
      Bairro: this.EnderecoFormGroup.get('bairro')?.value,
      Rua: this.EnderecoFormGroup.get('rua')?.value,
      Numero: this.EnderecoFormGroup.get('numero')?.value,
      Senha: this.AcessoFormGroup.get('senha')?.value,
      Email: this.AcessoFormGroup.get('email')?.value,
    }

    this.response.Post("Usuario","Cadastrar",this.request).subscribe(
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
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
