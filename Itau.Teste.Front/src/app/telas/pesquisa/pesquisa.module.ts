import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PesquisaComponent } from './pesquisa.component';
import { DetalheComponent } from './detalhe/detalhe.component';
import { FeatherModule } from 'angular-feather';
import { Edit3, Trash2 } from 'angular-feather/icons';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        FeatherModule.pick({ Edit3, Trash2 })
    ],
    exports: [
        PesquisaComponent,
        DetalheComponent
    ],
    declarations: [
        PesquisaComponent,
        DetalheComponent
    ],
    providers: [],
})

export class PesquisaModule {}