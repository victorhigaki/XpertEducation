using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Events;

internal class MatriculaPagamentoFinalizadoEvent : Event
{
    public Guid MatriculaId { get; private set; }

    public MatriculaPagamentoFinalizadoEvent(Guid matriculaId)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
    }
}