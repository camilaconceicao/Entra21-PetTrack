import { Component, OnInit} from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Endereco } from 'src/objects/Endereco/Endereco';
import { PetRequest } from 'src/objects/Pet/PetRequest';
import { RetornoPadrao } from 'src/objects/RetornoPadrao';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'pet-crud-component',
  templateUrl: './pet-crud.component.html',
  styleUrls: ['./pet-crud.component.css']
})
export class PetCrudComponent implements OnInit{
    //Variaveis operacionais
    loading: boolean = false;
    submit: boolean = false;
    hide = true;
    request!: PetRequest; 
    IsNew: boolean = true;

    //Formulário
    PerfilFormGroup!: FormGroup;
    EnderecoFormGroup!: FormGroup;
    DadosCadastraisFormGroup!: FormGroup;
  
    constructor(private _formBuilder: FormBuilder,private response: BaseService,
      private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.PerfilFormGroup = this._formBuilder.group({
          idPet: [undefined],
          nome: [undefined, Validators.required],
          foto: ["",Validators.required],
          raca: ["",Validators.required],
          porte: ["",Validators.required],
        });
      
        this.EnderecoFormGroup = this._formBuilder.group({
          cidade: ['',Validators.required],
          cep: ['', [Validators.minLength(8),Validators.required]],
          bairro: ['',Validators.required],
          rua: ['',Validators.required],
        });
      
        this.DadosCadastraisFormGroup = this._formBuilder.group({
          tipoPet: ["0"],
          descricao: ['',Validators.required],
          termo: [false]
        });

        this.route.params.subscribe(params => {
          if(params['id'] != undefined){
            this.IsNew = false;
            this.loading = true;
            this.response.Get("Pet","ConsultarViaId/" + params['id']).subscribe(
            (response: any) =>{        
              if(response.sucesso){
                this.PerfilFormGroup.setValue(response.data.informacoes);
                this.EnderecoFormGroup.setValue(response.data.endereco);
                this.DadosCadastraisFormGroup.setValue(response.data.dadosCadastrais);
              }
              else{
                this.toastr.error(response.mensagem, 'Mensagem:');
              }
              this.loading = false;
            });
          }
        });

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

    ChangeFoto = (event:any) => {
      let file = event.target.files[0];
      let reader = new FileReader();
      reader.readAsDataURL(file); 

      reader.onloadend = () => {
        let base64data: any = reader.result;
        this.PerfilFormGroup.get('foto')?.setValue(base64data);
      }
    };

    OpenFileUpload = () => {
      document.getElementById("customFile")?.click();
    }
  
    Salvar = () =>{
      this.submit = true;
      this.loading = true;
  
      if(this.PerfilFormGroup.invalid || this.DadosCadastraisFormGroup.invalid || this.EnderecoFormGroup.invalid){
        this.loading = false;
        this.toastr.error('<small>Preencha os campos corretamente no formulário!</small>', 'Mensagem:');
        return;
      }
  
      if(this.DadosCadastraisFormGroup.get('termo')?.value == false){
        this.loading = false;
        this.toastr.error('<small>Para prosseguir com o cadastro aceite os termos!</small>', 'Mensagem:');
        return;
      }
  
      this.request = {
        IdPet: this.PerfilFormGroup.get('idPet')?.value,
        Nome: this.PerfilFormGroup.get('nome')?.value,
        FotoBase64: this.PerfilFormGroup.get('foto')?.value,
        Raca: this.PerfilFormGroup.get('raca')?.value,
        Tamanho: Number.parseInt(this.PerfilFormGroup.get('porte')?.value),
        Cep: this.EnderecoFormGroup.get('cep')?.value,
        Cidade: this.EnderecoFormGroup.get('cidade')?.value,
        Bairro: this.EnderecoFormGroup.get('bairro')?.value,
        Rua: this.EnderecoFormGroup.get('rua')?.value,
        Descricao: this.DadosCadastraisFormGroup.get('descricao')?.value,
        TipoCadastro: Number.parseInt(this.DadosCadastraisFormGroup.get('tipoPet')?.value),
        UsuarioCadastroId: window.localStorage.getItem('IdUsuario')
      }

      if(this.IsNew){
        this.response.Post("Pet","Cadastrar",this.request).subscribe(
          (response: RetornoPadrao) =>{        
            if(response.sucesso){
              this.toastr.success(response.mensagem, 'Mensagem:');
              this.router.navigateByUrl('/cadastros-pet')
            }else{
              this.toastr.error(response.mensagem, 'Mensagem:');
            }
            this.loading = false;
          }
        );
      }
      else{
        this.response.Post("Pet","Editar",this.request).subscribe(
          (response: RetornoPadrao) =>{        
            if(response.sucesso){
              this.toastr.success(response.mensagem, 'Mensagem:');
              this.router.navigateByUrl('/cadastros-pet')
            }else{
              this.toastr.error(response.mensagem, 'Mensagem:');
            }
            this.loading = false;
          }
        );
      }
    }
}
