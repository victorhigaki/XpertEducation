using XpertEducation.GestaoAlunos.Application.ViewModels;

namespace XpertEducation.GestaoAlunos.Application.Queries;

public interface IAlunoQuery
{
    Task<AlunoViewModel> ObterPorId(Guid id);
}
