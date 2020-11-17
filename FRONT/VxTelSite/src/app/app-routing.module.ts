import { ContatoComponent } from './navegacao/contato/contato.component';
import { SimulacaoPlanosComponent } from './navegacao/simulacao-planos/simulacao-planos.component';
import { ConhecaPlanosComponent } from './navegacao/conheca-planos/conheca-planos.component';
import { LoginComponent } from './navegacao/login/login.component';
import { HomeComponent } from './navegacao/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'planos', component: ConhecaPlanosComponent},
  {path: 'simulacao', component: SimulacaoPlanosComponent},
  {path: 'contato', component: ContatoComponent},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
