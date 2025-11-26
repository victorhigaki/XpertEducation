using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoConteudo.Domain;
using XpertEducation.GestaoConteudo.Domain.Repositories;

namespace XpertEducation.GestaoConteudo.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly GestaoConteudoContext _context;

    public CursoRepository(GestaoConteudoContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public IEnumerable<Curso> ObterTodos()
    {
        return _context.Cursos.AsNoTracking().ToList();
    }

    public Curso ObterPorId(Guid id)
    {
        return _context.Cursos.AsNoTracking().Include(c => c.Aulas).FirstOrDefault(c => c.Id == id);
    }

    public void Adicionar(Curso curso)
    {
        _context.Cursos.AddAsync(curso);
    }

    public void AdicionarAula(Aula aula)
    {
        _context.Aulas.AddAsync(aula);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
