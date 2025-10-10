namespace XpertEducation.PagamentoFaturamento.Business.Models;

public class PagamentoPedido
{
    public Guid MatriculaId { get; set; }
    public Guid ClienteId { get; set; }
    public decimal Valor { get; set; }
    public DadosCartao DadosCartao { get; set; }
}