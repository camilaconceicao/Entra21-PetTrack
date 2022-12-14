import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {MatTabsModule} from '@angular/material/tabs';
import { AppRoutingModule } from './app.routing.module';
import { HomeComponent } from './app/home/home.component';
import { PetCareComponent } from './app/pet-care/pet-care.component';
import { PetTrackComponent } from './app/pet-track/pet-track.component';
import { LoginComponent } from './app/login/login.component';
import { CadastroComponent } from './app/cadastro/cadastro.component';
import { AdotaPetComponent } from './app/adota-pet/adota-pet.component';
import { ComunidadeComponent } from './app/comunidade/comunidade.component';
import { PopUpComponent } from './app/pop-up/pop-up.component';
import { TipoComponent } from './app/tipo/tipo.component';
import { MapaComponent } from './app/mapa/mapa.component';
import { TextErrorMessageComponent } from './components/text-error-message/text-error-message.component';
import { ReactiveFormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { ToastrModule } from 'ngx-toastr';
import {MatStepperModule,} from '@angular/material/stepper';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { AppComponent } from './app/base/app.component';
import { FooterComponent } from 'src/components/footer-component/footer.component';
import { NavbarComponent } from 'src/components/navbar-component/navbar.component';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule, MAT_DATE_LOCALE} from '@angular/material/core';
import {MatTooltipModule} from '@angular/material/tooltip';
import {SpinnerComponent } from './components/spinner-component/spinner.component';
import {PetGridComponent } from './app/pet-crud/grid/pet-grid.component';
import { DataGridComponent } from './components/data-grid/data-grid.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSelectModule} from '@angular/material/select';
import {MatMenuModule} from '@angular/material/menu';
import {MatSortModule} from '@angular/material/sort';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatTableModule} from '@angular/material/table';
import { PetCrudComponent } from './app/pet-crud/crud/pet-crud.component';
import { AuthTokenInterceptor } from './interceptor/header.interceptor';
import { Pagina500Component } from './app/pagina-500/pagina-500.component';
import { Pagina401Component } from './app/pagina-401/pagina-401.component';

const maskConfigFunction: () => Partial<IConfig> = () => {
  return {
    validation: true,
  };
};

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DataGridComponent,
    PetTrackComponent,
    PetCareComponent,
    AdotaPetComponent,
    LoginComponent,
    CadastroComponent,
    ComunidadeComponent,
    PopUpComponent,
    TipoComponent,
    MapaComponent,
    TextErrorMessageComponent,
    FooterComponent,
    NavbarComponent,
    SpinnerComponent,
    PetGridComponent,
    PetCrudComponent,
    Pagina500Component,
    Pagina401Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatMenuModule,
    MatSortModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatProgressBarModule,
    MatInputModule,
    MatTableModule,
    MatTabsModule,
    MatCheckboxModule,
    MatSelectModule,
    MatButtonModule,
    MatTooltipModule,
    MatDatepickerModule,
    MatPaginatorModule,
    MatNativeDateModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      enableHtml: true,
      progressBar: true,
      progressAnimation: 'decreasing',
      preventDuplicates: true
    }),
    NgxMaskModule.forRoot(maskConfigFunction),
    MatStepperModule,
    MatIconModule
  ],
  exports: [
    PopUpComponent,
  ],
  providers: [
  { provide: MAT_DATE_LOCALE, useValue: 'pt-br' },
  { provide: HTTP_INTERCEPTORS, useClass: AuthTokenInterceptor, multi: true },
],
  bootstrap: [AppComponent],

})
export class AppModule { }
