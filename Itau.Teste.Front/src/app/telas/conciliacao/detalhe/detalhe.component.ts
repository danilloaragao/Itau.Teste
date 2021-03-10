import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import Lancamento from 'src/app/interfaces/lancamento';
import { ApiLancamentoService } from 'src/app/service/api-lancamento.service';

@Component({
  selector: 'app-detalhe-tema',
  templateUrl: './detalhe.component.html',
  styleUrls: ['./detalhe.component.css']
})
export class DetalheComponent {
  @Input() lancamento: Lancamento = null
  @Input() index: number
  conciliado = false

  @Output() emmitStatus = new EventEmitter<Lancamento>();

  constructor(private apiService: ApiLancamentoService) { }

  trocaStatus(){
    this.emmitStatus.emit(this.lancamento)
  }

  background(): string {
    return this.index % 2 == 0 ? 'par' : 'impar'
  }
}
