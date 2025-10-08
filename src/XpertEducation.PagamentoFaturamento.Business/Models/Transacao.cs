using XpertEducation.Core.DomainObjects;
using XpertEducation.PagamentoFaturamento.Business.Enums;

namespace XpertEducation.PagamentoFaturamento.Business.Models;

public class Transacao : Entity
{
    public Guid PedidoId { get; set; }
    public Guid PagamentoId { get; set; }
    public decimal Valor { get; set; }
    public StatusTransacao StatusTransacao { get; set; }

    public Pagamento Pagamento { get; set; }
}