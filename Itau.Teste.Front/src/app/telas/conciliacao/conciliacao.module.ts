import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ConciliacaoComponent } from './conciliacao.component';
import { FeatherModule } from 'angular-feather';
import { CheckSquare, Search } from 'angular-feather/icons';
import { DetalheComponent } from './detalhe/detalhe.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        FeatherModule.pick({ CheckSquare, Search })
    ],
    exports: [
        ConciliacaoComponent,
        DetalheComponent
    ],
    declarations: [
        ConciliacaoComponent,
        DetalheComponent
    ],
    providers: [],
})

export class ConciliacaoModule {}