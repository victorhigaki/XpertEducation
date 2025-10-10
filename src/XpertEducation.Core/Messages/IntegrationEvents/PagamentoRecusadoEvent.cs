namespace XpertEducation.Core.Messages.IntegrationEvents;

public class PagamentoRecusadoEvent :IntegrationEvent
{
    public Guid MatriculaId { get; private set; }
    public Guid ClienteId { get; private set; }
    public Guid PagamentoId { get; private set; }
    public Guid TransacaoId { get; private set; }
    public decimal Total { get; private set; }

    public PagamentoRecusadoEvent(Guid matriculaId, Guid clienteId, Guid pagamentoId, Guid transacaoId, decimal total)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        ClienteId = clienteId;
        PagamentoId = pagamentoId;
        TransacaoId = transacaoId;
        Total = total;
    }
}
