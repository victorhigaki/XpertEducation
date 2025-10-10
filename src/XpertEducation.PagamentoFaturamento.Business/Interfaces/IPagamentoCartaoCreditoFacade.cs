using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Business.Interfaces
{
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Matricula pedido, Pagamento pagamento);
    }
}