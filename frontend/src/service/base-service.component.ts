import { HttpClient } from "@angular/common/http";
import { Injectable,EventEmitter } from '@angular/core';
import { environment } from "src/environments/environment.prod";

@Injectable({
    providedIn: 'root'
})

export class BaseService{
    
    //Variaveis
    request : HttpClient;
    rota: string
    logado = new EventEmitter<boolean>(); 

    //Constructor
    constructor(http: HttpClient){
        this.request = http;
        this.rota = environment.link;
    }

    Get(controller: string,metodo: string){
        return this.request.get<any>(this.rota + controller + '/' + metodo)
    };
    
    Post(controller: string,metodo: string,objetoEnvio: any){
        return this.request.post<any>(this.rota + controller + '/' + metodo,objetoEnvio)
    };

    UsuarioLogado(bool: boolean | undefined){
        this.logado.emit(bool);
    }

};