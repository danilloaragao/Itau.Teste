import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private apiService: ApiLancamentoService) { }
  atualizar() {
    if (this.lancamento.conciliado)
      return

    if (this.lancamento.valor <= 0) {
      alert('O valor do lancamento deve ser maior que zero.')
      return
    }

    if (confirm('Confirma a atualização do lancamento?')) {
      this.apiService.atualizar(this.lancamento)
        .then(resp => alert('Atualização realizada com sucesso!'))
        .catch(err => alert('Ocorreu uma falha ao atualizar o lancamento.'))
    }
  }

  excluir() {
    if (this.lancamento.conciliado)
      return

    if (confirm('Confirma a exclusão do lancamento?')) {
      this.apiService.excluir(this.lancamento.id)
        .then(resp => alert('Exclusão realizada com sucesso!'))
        .catch(err => alert('Ocorreu uma falha ao excluir o lancamento.'))
    }
  }

  selecaoTipoLancamento(tipoLancamento: number) {
    this.lancamento.tipo = Number(tipoLancamento)
  }

  background(): string {
    return this.index % 2 == 0 ? 'par' : 'impar'
  }
}
