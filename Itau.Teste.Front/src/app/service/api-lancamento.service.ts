import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CadastroLancamento from '../interfaces/cadastro-lancamento';
import Lancamento from '../interfaces/lancamento';
import RelatorioMensal from '../interfaces/relatorio-mensal';

@Injectable({
  providedIn: 'root'
})
export class ApiLancamentoService {
  constructor(private http: HttpClient) { }

  private baseUrl = 'http://localhost:8081/LancamentoFinanceiro'
  
  async gravar(lancamento:CadastroLancamento):Promise<string> {
    return this.http.post<string>(`${this.baseUrl}`, lancamento).toPromise()
  }

  async consultarPeriodo(inicio:Date, fim:Date):Promise<Lancamento[]>{
    return this.http.get<Lancamento[]>(`${this.baseUrl}/${inicio}/${fim}`).toPromise()
  }
  
  async consultarDia(dia:Date):Promise<Lancamento[]>{
    return this.http.get<Lancamento[]>(`${this.baseUrl}/${dia}`).toPromise()
  }

  async extrairRelatorio(mesReferencia:Date):Promise<RelatorioMensal>{
    const data = new Date(mesReferencia)
    return this.http.get<RelatorioMensal>(`${this.baseUrl}/Relatorio/${data.getFullYear()}-${("0"+(data.getMonth()+1)).slice(-2)}-${("0"+data.getDate()).slice(-2)}`).toPromise()
  }

  async atualizar(lancamento:Lancamento):Promise<string>{
    return this.http.put<string>(`${this.baseUrl}`, lancamento).toPromise()
  }

  async atualizarLote(lancamentos:Lancamento[]):Promise<any>{
    return this.http.put<string>(`${this.baseUrl}/Lote`, lancamentos).toPromise()
  }

  async excluir(id:number):Promise<string>{
    return this.http.delete<string>(`${this.baseUrl}/${id}`).toPromise()
  }


}
