using XpertEducation.GestaoConteudo.Application.Extensions;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain.Repositories;

namespace XpertEducation.GestaoConteudo.Application.AppServices;

public class CursoAppService : ICursoAppService
{
    private readonly ICursoRepository _cursoRepository;

    public CursoAppService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<IEnumerable<CursoViewModel>> ObterTodos()
    {
        var cursos = await _cursoRepository.ObterTodos();
        return cursos.ToViewModel();
    }

    public async Task<CursoViewModel> ObterPorId(Guid id)
    {
        var curso = await _cursoRepository.ObterPorId(id);
        if (curso == null) return null;
        return curso.ToViewModel();
    }

    public async Task<CursoViewModel> Adicionar(CursoViewModel cursoViewModel)
    {
        var curso = cursoViewModel.ToModel();
        _cursoRepository.Adicionar(curso);
        await _cursoRepository.UnitOfWork.Commit();
        cursoViewModel.Id = curso.Id;
        return cursoViewModel;
    }

    public async Task AdicionarAula(AulaViewModel aulaViewModel)
    {
        var aula = aulaViewModel.ToModel();
        _cursoRepository.AdicionarAula(aula);
        await _cursoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _cursoRepository?.Dispose();
    }
}
