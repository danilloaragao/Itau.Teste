import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CadastroLancamento from '../interfaces/cadastro-lancamento';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) { }

  private baseUrl = 'http://localhost:8081/'
  
  async gravar(lancamento:CadastroLancamento):Promise<string> {
    return this.http.post<string>(`${this.baseUrl}LancamentoFinanceiro`, lancamento).toPromise()
  }
}
