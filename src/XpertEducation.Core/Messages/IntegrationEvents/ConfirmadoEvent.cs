namespace XpertEducation.Core.Messages.IntegrationEvents;

public class ConfirmadoEvent : IntegrationEvent
{
    public Guid MatriculaId { get; private set; }
    public Guid ClienteId { get; private set; }
    public decimal Total { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }

    public ConfirmadoEvent(Guid matriculaId, Guid clienteId, decimal total, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        ClienteId = clienteId;
        Total = total;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }
}
