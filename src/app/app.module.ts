import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app.routing.module';
import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { PetCareComponent } from './pet-care/pet-care.component';
import { PetTrackComponent } from './pet-track/pet-track.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { AdotaPetComponent } from './adota-pet/adota-pet.component';
import { ComunidadeComponent } from './comunidade/comunidade.component';
import { PopUpComponent } from './pop-up/pop-up.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PetTrackComponent,
    PetCareComponent,
    AdotaPetComponent,
    LoginComponent,
    CadastroComponent,
    ComunidadeComponent,
    PopUpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
