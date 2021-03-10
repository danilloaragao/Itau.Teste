import { Component, Input, OnInit } from '@angular/core';
import LancamentosDia from 'src/app/interfaces/lancamentos-dia';

@Component({
  selector: 'app-detalhe-dia',
  templateUrl: './detalhe-dia.component.html',
  styleUrls: ['./detalhe-dia.component.css']
})
export class DetalheDiaComponent implements OnInit {

  constructor() { }

  @Input() lancamentosDia: LancamentosDia
  @Input() index: number
  
  pegarDia(){
    const dia = new Date(this.lancamentosDia.diaReferencia)
    return `${("0" + dia.getDate()).slice(-2)}/${("0" + (dia.getMonth()+1)).slice(-2)}/${dia.getFullYear()}`
  }

  pegarHora(dataHora:Date){

    this.lancamentosDia.lancamentos[0].dataHoraLancamento

    const dia = new Date(dataHora)
    return `${("0" + dia.getHours()).slice(-2)}:${("0" + (dia.getMinutes()+1)).slice(-2)}`
  }

  ngOnInit(): void {
  }

}
