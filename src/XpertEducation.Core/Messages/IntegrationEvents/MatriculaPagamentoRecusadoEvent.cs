namespace XpertEducation.Core.Messages.IntegrationEvents;

public class MatriculaPagamentoRecusadoEvent : IntegrationEvent
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }
    public Guid PagamentoId { get; private set; }
    public Guid TransacaoId { get; private set; }
    public decimal Total { get; private set; }

    public MatriculaPagamentoRecusadoEvent(Guid matriculaId, Guid alunoId, Guid pagamentoId, Guid transacaoId, decimal total)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        AlunoId = alunoId;
        PagamentoId = pagamentoId;
        TransacaoId = transacaoId;
        Total = total;
    }
}
