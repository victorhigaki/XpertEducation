namespace XpertEducation.PagamentoFaturamento.Business.Models;

public class PagamentoPedido
{
    public Guid PedidoId { get; set; }
    public Guid ClienteId { get; set; }
    public decimal Total { get; set; }
    public DadosCartao DadosCartao { get; set; }
}