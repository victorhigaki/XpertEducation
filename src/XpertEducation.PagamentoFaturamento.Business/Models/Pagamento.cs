using XpertEducation.Core.DomainObjects;

namespace XpertEducation.PagamentoFaturamento.Business.Models;

public class Pagamento : Entity, IAggregateRoot
{
    public Guid PedidoId { get; set; }
    public string Status { get; set; }
    public decimal Valor { get; set; }

    public DadosCartao DadosCartao { get; set; }

    public Transacao Transacao { get; set; }
}
