using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Events;

internal class MatriculaAtualizadaEvent : Event
{
    public Guid MatriculaId { get; private set; }
    public Guid CursoId { get; private set; }
    public Guid AlunoId { get; private set; }

    public MatriculaAtualizadaEvent(Guid matriculaId, Guid cursoId, Guid alunoId)
    {
        MatriculaId = matriculaId;
        CursoId = cursoId;
        AlunoId = alunoId;
    }
}