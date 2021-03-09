import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CadastroComponent } from './cadastro.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        CadastroComponent
    ],
    declarations: [
        CadastroComponent
    ],
    providers: [],
})

export class CadastroModule {}