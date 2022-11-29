import { Component, OnInit } from '@angular/core';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'navbar-component',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']

})
export class NavbarComponent implements OnInit{
  //Variaveis operacionais
  usuarioLogado: boolean = false;

  constructor(baseService: BaseService){
    baseService.logado.subscribe((bool: boolean) => {
      this.usuarioLogado = bool;
    });
  }
  ngOnInit(): void {
    this.usuarioLogado = window.localStorage.getItem('IdUsuario') != undefined;
  }
}
