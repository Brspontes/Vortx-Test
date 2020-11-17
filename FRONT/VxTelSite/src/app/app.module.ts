import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HomeComponent } from './navegacao/home/home.component';
import { LoginComponent } from './navegacao/login/login.component';
import { ConhecaPlanosComponent } from './navegacao/conheca-planos/conheca-planos.component';
import { VxTelApiService } from './Services/VxTelApi.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';
import { SimulacaoPlanosComponent } from './navegacao/simulacao-planos/simulacao-planos.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContatoComponent } from './navegacao/contato/contato.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    ConhecaPlanosComponent,
    SimulacaoPlanosComponent,
    ContatoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgBrazil,
    TextMaskModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [
    VxTelApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
