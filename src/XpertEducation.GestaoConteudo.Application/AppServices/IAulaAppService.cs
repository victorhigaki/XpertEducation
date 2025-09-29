using XpertEducation.GestaoConteudo.Application.ViewModels;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public interface IAulaAppService
{
    Task AdicionarAula(AulaViewModel aulaViewModel);
}