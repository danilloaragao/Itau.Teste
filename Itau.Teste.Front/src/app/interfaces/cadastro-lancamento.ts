import { TipoLancamento } from "../enums/tipo-lancamento.enum";

export default interface CadastroLancamento{
    dataHoraLancamento: Date,
    valor: number,
    tipo: TipoLancamento
  }