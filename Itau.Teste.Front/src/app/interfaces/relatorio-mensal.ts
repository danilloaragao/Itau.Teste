import LancamentosDia from "./lancamentos-dia";

export default interface RelatorioMensal{
    mesReferencia: Date
    lancamentosDia: LancamentosDia[]
    totalCredito: number
    totalDebito: number
    saldo: number
  }