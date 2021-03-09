import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CadastroComponent } from './cadastro.component';
import { FeatherModule } from 'angular-feather';
import { Check } from 'angular-feather/icons';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        FeatherModule.pick({ Check })
    ],
    exports: [
        CadastroComponent,
        FeatherModule
    ],
    declarations: [
        CadastroComponent
    ],
    providers: [],
})

export class CadastroModule {}