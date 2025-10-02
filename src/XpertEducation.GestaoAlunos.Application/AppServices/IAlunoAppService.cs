using XpertEducation.GestaoAlunos.Application.ViewModels;

namespace XpertEducation.GestaoAlunos.Application.AppServices;

public interface IAlunoAppService : IDisposable
{
    Task AdicionarAsync(AlunoViewModel alunoViewModel);
    Task<MatriculaViewModel> ObterMatriculaPorIdAsync(Guid matriculaId);
}