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

    public async Task<IEnumerable<CursoViewModel>> ObterTodos()
    {
        var cursos = await _cursoRepository.ObterTodosAsync();

        List<CursoViewModel> cursosViewModel = [];
        cursos.ToList().ForEach(curso =>
        {
            cursosViewModel.Add(new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Valor = curso.Valor,                
                ConteudoProgramatico = curso.ConteudoProgramatico
            });
        });

        return cursosViewModel;
    }

    public async Task<CursoViewModel> ObterPorId(Guid id)
    {
        var curso = await _cursoRepository.ObterPorIdAsync(id);
        return new CursoViewModel
        {
            Id = curso.Id,
            Nome = curso.Nome,
            ConteudoProgramatico = curso.ConteudoProgramatico,
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
        Curso curso = new(cursoViewModel.Nome, cursoViewModel.ConteudoProgramatico, cursoViewModel.Valor);
        await _cursoRepository.AdicionarAsync(curso);
        await _cursoRepository.UnitOfWork.Commit();
        cursoViewModel.Id = curso.Id;
        return cursoViewModel;
    }

    public void Dispose()
    {
        _cursoRepository?.Dispose();
    }
}
