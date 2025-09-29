using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public class AulaAppService : IAulaAppService
{
    private readonly ICursoRepository _cursoRepository;

    public AulaAppService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task AdicionarAula(AulaViewModel aulaViewModel)
    {
        await _cursoRepository.AdicionarAulaAsync(new Aula(aulaViewModel.Titulo, aulaViewModel.ConteudoAula, aulaViewModel.Material));
        await _cursoRepository.UnitOfWork.Commit();
    }
}
