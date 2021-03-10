import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PrincipalComponent } from './principal.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        PrincipalComponent
    ],
    declarations: [
        PrincipalComponent
    ],
    providers: [],
})

export class PrincipalModule {}