import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PesquisaComponent } from './pesquisa.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        PesquisaComponent
    ],
    declarations: [
        PesquisaComponent
    ],
    providers: [],
})

export class PesquisaModule {}