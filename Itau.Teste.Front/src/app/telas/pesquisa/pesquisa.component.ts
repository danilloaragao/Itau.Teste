import { Component, Input, OnInit } from '@angular/core';
import Lancamento from 'src/app/interfaces/lancamento';
import { ApiLancamentoService } from 'src/app/service/api-lancamento.service';

@Component({
  selector: 'app-pesquisa',
  templateUrl: './pesquisa.component.html',
  styleUrls: ['./pesquisa.component.css']
})
export class PesquisaComponent implements OnInit {

  constructor(private apiService: ApiLancamentoService) {}

  public dataInicio: Date = null
  public dataFim: Date = null

  @Input() lancamentos: Lancamento[]

  ngOnInit(): void {
  }

  pesquisar() {
    if (!this.dataInicio || !this.dataFim) {
      alert('Obrigatório informar o perído da pesquisa')
      return
    }

    if (this.dataInicio > this.dataFim) {
      alert('A data inicial não pode ser superior á da final')
      return
    }

    this.apiService.consultarPeriodo(this.dataInicio, this.dataFim)
      .then(resp => this.lancamentos = resp)
      .catch(err => {
        alert('Ocorreu uma falha, tente novamente mais tarde.')
      })
  }
}
