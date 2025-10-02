using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface ICursoAppService : IDisposable
{
    Task<CursoViewModel> ObterCursoPorIdAsync(Guid id);
    Task AdicionarCursoAsync(CursoViewModel cursoViewModel);
}
