using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface IAulaAppService
{
    Task<CursoViewModel> ObterCursoPorId(Guid cursoId);
    Task AdicionarAula(AulaViewModel aulaViewModel);
}