import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataPet, PetResponse } from 'src/objects/Pet/PetResponse';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'app-adota-pet',
  templateUrl: './adota-pet.component.html',
  styleUrls: ['./adota-pet.component.css']
})
export class AdotaPetComponent{
  loading: boolean = false;
  lPetz: Array<DataPet> = [];

  constructor(private response: BaseService,private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
    this.loading = true;
    this.response.Get("Pet","ConsultarPetsAdocao/").subscribe(
      (response: PetResponse) =>{        
        if(response.sucesso){
          this.loading = false;
          response.data.forEach(element =>{
            this.lPetz.push(element);
          });
        }
        else{
          this.toastr.error("Houve um problema ao consultar os pets volte mais tarde!","Mensagem")
        }
      }
    );
  }

}
