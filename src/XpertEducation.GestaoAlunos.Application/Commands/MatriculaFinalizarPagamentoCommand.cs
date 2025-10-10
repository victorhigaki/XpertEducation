using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class MatriculaFinalizarPagamentoCommand : Command
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }

    public MatriculaFinalizarPagamentoCommand(Guid matriculaId, Guid alunoId)
    {
        MatriculaId = matriculaId;
        AlunoId = alunoId;
    }
}
