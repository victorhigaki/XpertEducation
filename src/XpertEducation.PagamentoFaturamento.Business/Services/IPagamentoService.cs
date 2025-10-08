using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Business.Services;

public interface IPagamentoService
{
    Task<Transacao> RealizarPagamento(PagamentoPedido pagamento);
}