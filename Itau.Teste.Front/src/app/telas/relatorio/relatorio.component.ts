import { Component, Input, OnInit } from '@angular/core';
import Lancamento from 'src/app/interfaces/lancamento';
import RelatorioMensal from 'src/app/interfaces/relatorio-mensal';
import { ApiLancamentoService } from 'src/app/service/api-lancamento.service';

@Component({
  selector: 'app-relatorio',
  templateUrl: './relatorio.component.html',
  styleUrls: ['./relatorio.component.css']
})
export class RelatorioComponent implements OnInit {

  constructor(private apiService: ApiLancamentoService) { }

  @Input() mesReferencia: Date = null
  @Input() relatorioMensal: RelatorioMensal = null

  ngOnInit(): void {
  }

  pegarMesRefenciaTexto() {
    if (!this.mesReferencia)
      return ''
    const meses = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']
    return `${meses[this.mesReferencia.getMonth()]} de ${this.mesReferencia.getFullYear()}`
  }

  escolhaMes(data: Date) {
    const novaData = new Date(data)
    this.mesReferencia = new Date(novaData.getFullYear(), novaData.getMonth(), novaData.getDate() + 5)
    this.relatorioMensal = null
  }

  pesquisar() {
    if (!this.mesReferencia) {
      alert('Obrigatório informar o mês de referência')
      return
    }

    this.apiService.extrairRelatorio(this.mesReferencia)
      .then(resp => {
        this.relatorioMensal = resp
        console.log(this.relatorioMensal)
      })
      .catch(err => alert('Ocorreu uma falha, tente novamente mais tarde.'))
  }
}

