using XpertEducation.Core.Messages;
using XpertEducation.GestaoAlunos.Domain.Enums;

namespace XpertEducation.GestaoAlunos.Application.Events;
public class MatriculaRealizadaEvent : Event
{
    public Guid MatriculaId { get; private set; }
    public Guid CursoId { get; private set; }
    public Guid AlunoId { get; private set; }
    public string CursoNome { get; private set; }
    public MatriculaStatus Status { get; set; }

    public MatriculaRealizadaEvent(Guid matriculaId, Guid cursoId, Guid alunoId, string cursoNome, MatriculaStatus status)
    {
        MatriculaId = matriculaId;
        CursoId = cursoId;
        AlunoId = alunoId;
        CursoNome = cursoNome;
        Status = status;
    }
}
