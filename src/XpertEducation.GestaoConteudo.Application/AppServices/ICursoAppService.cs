using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface ICursoAppService : IDisposable
{
    Task<IEnumerable<CursoViewModel>> ObterTodos();
    Task<CursoViewModel> ObterPorId(Guid id);
    Task<CursoViewModel> Adicionar(CursoViewModel cursoViewModel);
    Task AdicionarAula(AulaViewModel aulaViewModel);
}
