import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RelatorioComponent } from './relatorio.component';
import { DetalheDiaComponent } from './detalhe-dia/detalhe-dia.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule
    ],
    exports: [
        RelatorioComponent
    ],
    declarations: [
        RelatorioComponent,
        DetalheDiaComponent
    ],
    providers: [],
})

export class RelatorioModule {}