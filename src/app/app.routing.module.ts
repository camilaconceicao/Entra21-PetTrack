import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PetTrackComponent } from './pet-track/pet-track.component';
import { PetCareComponent } from './pet-care/pet-care.component';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { AdotaPetComponent } from './adota-pet/adota-pet.component';
import { ComunidadeComponent } from './comunidade/comunidade.component';

//Definir as rotas:
const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'home', component:HomeComponent},
    {path:'pet-track', component:PetTrackComponent},
    {path:'pet-care', component:PetCareComponent},
    {path:'adota-pet', component:AdotaPetComponent},
    {path:'login', component:LoginComponent},
    {path:'cadastro', component:CadastroComponent},
    {path: 'comunidade', component:ComunidadeComponent}  //nome da pasta que criou, indiferente aspas simples ou duplas
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }