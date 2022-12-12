import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataPet, PetResponse } from 'src/objects/Pet/PetResponse';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'app-pet-track',
  templateUrl: './pet-track.component.html',
  styleUrls: ['./pet-track.component.css']
})
export class PetTrackComponent{
  loading: boolean = false;
  lPetz: Array<DataPet> = [];

  constructor(private response: BaseService,private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
    this.loading = true;
    this.response.Get("Pet","ConsultarPetsPerdidos/").subscribe(
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
