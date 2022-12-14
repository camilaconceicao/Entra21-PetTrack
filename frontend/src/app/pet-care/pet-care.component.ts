import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CareResponse, DataCare } from 'src/objects/Care/CareResponse';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'app-pet-care',
  templateUrl: './pet-care.component.html',
  styleUrls: ['./pet-care.component.css']
})
export class PetCareComponent{
  loading: boolean = false;
  lCares: Array<DataCare> = [];

  constructor(private response: BaseService,private toastr: ToastrService,private router: Router,private route: ActivatedRoute) {
    this.loading = true;
    this.response.Get("Care","ConsultarTodos/").subscribe(
      (response: CareResponse) =>{        
        if(response.sucesso){
          this.loading = false;
          response.data.itens.forEach(element =>{
            this.lCares.push(element);
          });
        }
        else{
          this.toastr.error("Houve um problema ao consultar os pet care volte mais tarde!","Mensagem")
        }
      }
    );
  }

}
