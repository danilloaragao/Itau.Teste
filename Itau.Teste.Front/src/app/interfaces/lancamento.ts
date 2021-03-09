export default interface Lancamento{
    id: number,
    dataHoraLancamento: Date,
    valor: number,
    tipo: number,
    conciliado: boolean
}