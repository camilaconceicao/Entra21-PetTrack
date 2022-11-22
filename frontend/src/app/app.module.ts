import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MatTabsModule} from '@angular/material/tabs';
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
import { TipoComponent } from './tipo/tipo.component';
import { MapaComponent } from './mapa/mapa.component';
import { TextErrorMessageComponent } from './text-error-message/text-error-message.component';
import { ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatStepperModule} from '@angular/material/stepper';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';

const maskConfigFunction: () => Partial<IConfig> = () => {
  return {
    validation: true,
  };
};

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
    PopUpComponent,
    TipoComponent,
    MapaComponent,
    TextErrorMessageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    MatTabsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      enableHtml: true,
      progressBar: true,
      progressAnimation: 'decreasing',
      preventDuplicates: true
    }),
    NgxMaskModule.forRoot(maskConfigFunction),
  ],
  exports: [
    PopUpComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
