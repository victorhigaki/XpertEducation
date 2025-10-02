using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Application.AppServices;
public class CursoAppService : ICursoAppService
{
    private readonly ICursoRepository _cursoRepository;

    public CursoAppService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public async Task<CursoViewModel> ObterCursoPorIdAsync(Guid id)
    {
        var curso = await _cursoRepository.ObterCursoPorIdAsync(id);
        return new CursoViewModel
        {
            Id = curso.Id,
            Nome = curso.Nome,
            ConteudoProgramatico = curso.ConteudoProgramatico
        };
    }

    public async Task AdicionarCursoAsync(CursoViewModel cursoViewModel)
    {
        Curso curso = new(cursoViewModel.Nome, cursoViewModel.ConteudoProgramatico);
        await _cursoRepository.AdicionarCursoAsync(curso);
        await _cursoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _cursoRepository?.Dispose();
    }

}
