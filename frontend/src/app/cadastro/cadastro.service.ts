import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {

  public apiUrl:string = 'http://localhost:8080/cadastro/'
  public httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*'
    })
  };

  constructor(
    public http: HttpClient
  ) { }

  salvar(dados: any) {
    return this.http.post(this.apiUrl, dados, this.httpOptions);
  }
}
