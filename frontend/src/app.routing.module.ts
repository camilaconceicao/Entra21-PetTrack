import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { PetTrackComponent } from './app/pet-track/pet-track.component';
import { PetCareComponent } from './app/pet-care/pet-care.component';
import { LoginComponent } from './app/login/login.component';
import { CadastroComponent } from './app/cadastro/cadastro.component';
import { AdotaPetComponent } from './app/adota-pet/adota-pet.component';
import { ComunidadeComponent } from './app/comunidade/comunidade.component';
import { PopUpComponent } from './app/pop-up/pop-up.component';
import { TipoComponent } from './app/tipo/tipo.component';
import { MapaComponent } from './app/mapa/mapa.component';
import { PetGridComponent } from './app/pet-crud/grid/pet-grid.component';
import { PetCrudComponent } from './app/pet-crud/crud/pet-crud.component';

//Definir as rotas:
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'pet-track', component: PetTrackComponent },
  { path: 'pet-care', component: PetCareComponent },
  { path: 'adota-pet', component: AdotaPetComponent},
  { path: 'login', component: LoginComponent },
  { path: 'cadastro', component: CadastroComponent },
  { path: 'comunidade', component: ComunidadeComponent },
  { path: 'pop-up', component: PopUpComponent },
  { path: 'tipo', component: TipoComponent},
  { path: 'mapa', component: MapaComponent},
  { path: 'cadastros-pet/novo-pet', component: PetCrudComponent},
  { path: 'editar-pet/:id', component: PetCrudComponent},
  { path: 'cadastros-pet', component: PetGridComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
