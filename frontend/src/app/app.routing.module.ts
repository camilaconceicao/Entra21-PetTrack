import { AuthService } from './login/auth.service';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PetTrackComponent } from './pet-track/pet-track.component';
import { PetCareComponent } from './pet-care/pet-care.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { AdotaPetComponent } from './adota-pet/adota-pet.component';
import { ComunidadeComponent } from './comunidade/comunidade.component';
import { PopUpComponent } from './pop-up/pop-up.component';
import { TipoComponent } from './tipo/tipo.component';
import { MapaComponent } from './mapa/mapa.component';

//Definir as rotas:
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'pet-track', component: PetTrackComponent },
  { path: 'pet-care', component: PetCareComponent },
  { path: 'adota-pet', component: AdotaPetComponent, canActivate:[AuthService]},
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'comunidade', component: ComunidadeComponent },
  { path: 'pop-up', component: PopUpComponent },
  { path: 'tipo', component: TipoComponent},
  { path: 'teste', component: MapaComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
