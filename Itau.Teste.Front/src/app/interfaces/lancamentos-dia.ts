import Lancamento from "./lancamento"

export default interface LancamentosDia{
  diaReferencia: Date,
  lancamentos: Lancamento[],
  totalCredito: number,
  totalDebito: number,
  saldo: number
}
