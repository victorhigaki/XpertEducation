using XpertEducation.Core.DomainObjects;

namespace XpertEducation.PagamentoFaturamento.AntiCorruption;

public class Pagamento : IAggregateRoot
{
    public DadosCartao DadosCartao { get; private set; }
    public StatusPagamento StatusPagamento { get; private set; }

    public Pagamento(DadosCartao dadosCartao)
    {
        DadosCartao = dadosCartao;
        //StatusPagamento = StatusPagamento.AguardandoPagamento;
    }
}
