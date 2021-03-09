
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastroComponent } from './telas/cadastro/cadastro.component';
import { ConciliacaoComponent } from './telas/conciliacao/conciliacao.component';
import { PesquisaComponent } from './telas/pesquisa/pesquisa.component';
import { PrincipalComponent } from './telas/principal/principal.component';
import { RelatorioComponent } from './telas/relatorio/relatorio.component';

const appRoutes: Routes = [
  {path:'', component: PrincipalComponent},
  {path:'cadastro', component: CadastroComponent},
  {path:'pesquisa', component: PesquisaComponent},
  {path:'conciliacao', component: ConciliacaoComponent},
  {path:'relatorio', component: RelatorioComponent},
  // {path:'**', redirectTo: ''},
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }