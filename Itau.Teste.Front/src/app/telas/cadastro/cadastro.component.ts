import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TipoLancamento } from 'src/app/enums/tipo-lancamento.enum';
import CadastroLancamento from 'src/app/interfaces/cadastro-lancamento';
import { ApiLancamentoService } from 'src/app/service/api-lancamento.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  constructor(private apiService: ApiLancamentoService, private router: Router) {
  }

  @Input() public lancamento: CadastroLancamento = {
    dataHoraLancamento: null,
    tipo: TipoLancamento.Debito,
    valor: 0
  }

  ngOnInit(): void {
  }

  selecaoTipoLancamento(tipoLancamento: number) {
    this.lancamento.tipo = Number(tipoLancamento)
  }

  cadastrar() {
    if(!this.lancamento.dataHoraLancamento){
      alert('Escolha a data e hora do lançamento')
    }

    if (this.lancamento.valor <= 0) {
      alert('O valor do lançamento deve ser maior que zero')
      return
    }

    this.apiService.gravar(this.lancamento).
      then(resp => {
        alert('Cadastro efetuado com sucesso')
        location.reload()
      })
      .catch(err => {
        alert('Algo deu errado com a sua solicitação.')
      })
  }
}
