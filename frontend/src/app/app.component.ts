import { Component } from '@angular/core';
import { AuthService } from './cadastro/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title = 'Hello World, Entra21 SENAC.';

  constructor(private authService:AuthService){

  }
}