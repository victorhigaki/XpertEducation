using XpertEducation.GestaoConteudo.Application.Extensions;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.GestaoConteudo.Domain;
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
        var cursos = _cursoRepository.ObterTodos();

        List<CursoViewModel> cursosViewModel = [];
        cursos.ToList().ForEach(curso =>
        {
            cursosViewModel.Add(new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Valor = curso.Valor,
                ConteudoProgramatico = curso.ConteudoProgramatico.ToViewModel(),
            });
        });

        return cursosViewModel;
    }

    public async Task<CursoViewModel> ObterPorId(Guid id)
    {
        var curso = _cursoRepository.ObterPorId(id);
        if (curso == null) return null;
        return new CursoViewModel
        {
            Id = curso.Id,
            Nome = curso.Nome,
            ConteudoProgramatico = curso.ConteudoProgramatico.ToViewModel(),
            Valor = curso.Valor,
            Aulas = curso.Aulas.Select(a => new AulaViewModel
            {
                Id = a.Id,
                Titulo = a.Titulo,
            }).ToList()
        };
    }

    public async Task<CursoViewModel> Adicionar(CursoViewModel cursoViewModel)
    {
        Curso curso = new(cursoViewModel.Nome, cursoViewModel.ConteudoProgramatico.ToModel(), cursoViewModel.Valor);
        _cursoRepository.Adicionar(curso);
        await _cursoRepository.UnitOfWork.Commit();
        cursoViewModel.Id = curso.Id;
        return cursoViewModel;
    }

    public async Task AdicionarAula(AulaViewModel aulaViewModel)
    {
        _cursoRepository.AdicionarAula(new Aula(aulaViewModel.CursoId, aulaViewModel.Titulo, aulaViewModel.ConteudoAula, aulaViewModel.Material));
        await _cursoRepository.UnitOfWork.Commit();
    }

    public void Dispose()
    {
        _cursoRepository?.Dispose();
    }
}
