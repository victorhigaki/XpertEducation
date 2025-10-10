using XpertEducation.GestaoAlunos.Application.ViewModels;

namespace XpertEducation.GestaoAlunos.Application.Queries;

public interface IMatriculaQueries
{
    public Task<MatriculaViewModel> ObterMatriculaAluno(Guid alunoId);
}
