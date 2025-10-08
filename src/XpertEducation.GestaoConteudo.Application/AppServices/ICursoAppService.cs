using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface ICursoAppService : IDisposable
{
    Task<IEnumerable<CursoViewModel>> ObterTodosAsync();
    Task<CursoViewModel> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(CursoViewModel cursoViewModel);
}
