import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'footer-component',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})

export class FooterComponent implements OnInit{
  //Variaveis operacionais
  usuarioLogado:boolean = false;

  constructor(private response: BaseService,private router: Router){
    response.logado.subscribe((bool: boolean) => {
      this.usuarioLogado = bool;
    });
  }

  ngOnInit(): void {
    this.usuarioLogado = window.localStorage.getItem('IdUsuario') != undefined;
  }

  Deslogar = () =>{
    window.localStorage.clear();
    this.response.UsuarioLogado(false);
    this.router.navigateByUrl('/');
  };
}
