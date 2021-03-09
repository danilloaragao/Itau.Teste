import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing.module';
import { CadastroModule } from './telas/cadastro/cadastro.module';
import { ConciliacaoModule } from './telas/conciliacao/conciliacao.module';
import { PesquisaModule } from './telas/pesquisa/pesquisa.module';
import { PrincipalModule } from './telas/principal/principal.module';
import { RelatorioModule } from './telas/relatorio/relatorio.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    CommonModule,
    BrowserModule,
    FormsModule,
    CadastroModule,
    ConciliacaoModule,
    PesquisaModule,
    PrincipalModule,
    RelatorioModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
