import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CadastroLancamento from '../interfaces/cadastro-lancamento';
import Lancamento from '../interfaces/lancamento';

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

  async atualizar(lancamento:Lancamento):Promise<string>{
    return this.http.put<string>(`${this.baseUrl}`, lancamento).toPromise()
  }

  async excluir(id:number):Promise<string>{
    return this.http.delete<string>(`${this.baseUrl}/${id}`).toPromise()
  }
}
