import { Component, Input, OnInit } from '@angular/core';
import Lancamento from 'src/app/interfaces/lancamento';
import { ApiLancamentoService } from 'src/app/service/api-lancamento.service';

@Component({
  selector: 'app-conciliacao',
  templateUrl: './conciliacao.component.html',
  styleUrls: ['./conciliacao.component.css']
})
export class ConciliacaoComponent implements OnInit {

  constructor(private apiService: ApiLancamentoService) {}

  public dataConciliacao: Date = null

  @Input() lancamentos: Lancamento[]

  ngOnInit(): void {
  }

  atualizaLancamento(lancamento: Lancamento) {
    this.lancamentos[this.lancamentos.indexOf(lancamento)].conciliado = lancamento.conciliado
  }

  pesquisar() {
    if (!this.dataConciliacao) {
      alert('Obrigatório informar o perído da pesquisa')
      return
    }
    this.apiService.consultarDia(this.dataConciliacao)
      .then(resp => this.lancamentos = resp.filter( r =>! r.conciliado))
      .catch(err => alert('Ocorreu uma falha, tente novamente mais tarde.'))
  }

  conciliar(){
    const qtdConciliar = this.lancamentos.filter(l => l.conciliado).length
     if(qtdConciliar == 0)
    return

    if(confirm(`Você está conciliando ${qtdConciliar} de ${this.lancamentos.length} lançamentos.\nDeseja continuar?`)){
      this.apiService.atualizarLote(this.lancamentos)
        .then(resp => {
          alert(resp.mensagem)
          location.reload()
        })
        .catch(err => alert(err.mensagem))
    }
  }
}
