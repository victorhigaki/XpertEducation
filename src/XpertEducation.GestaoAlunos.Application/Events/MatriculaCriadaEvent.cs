using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Events;

public class MatriculaCriadaEvent : Event
{
    public Guid MatriculaId { get; private set; }
    public Guid CursoId { get; private set; }
    public Guid AlunoId { get; private set; }

    public MatriculaCriadaEvent(Guid matriculaId, Guid cursoId, Guid alunoId)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        CursoId = cursoId;
        AlunoId = alunoId;
    }
}