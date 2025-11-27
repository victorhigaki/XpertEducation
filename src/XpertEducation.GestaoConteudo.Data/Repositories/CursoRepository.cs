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

    public async Task<IEnumerable<Curso>> ObterTodos()
    {
        return await _context.Cursos.AsNoTracking().ToListAsync();
    }

    public async Task<Curso> ObterPorId(Guid id)
    {
        return await _context.Cursos.AsNoTracking().Include(c => c.Aulas).FirstOrDefaultAsync(c => c.Id == id);
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
