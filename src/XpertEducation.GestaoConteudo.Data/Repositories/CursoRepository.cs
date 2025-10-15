using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoConteudo.Domain;

namespace XpertEducation.GestaoConteudo.Data.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly GestaoConteudoContext _context;

    public CursoRepository(GestaoConteudoContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Curso>?> ObterTodosAsync()
    {
        return await _context.Cursos.AsNoTracking().ToListAsync();
    }

    public async Task<Curso?> ObterPorIdAsync(Guid id)
    {
        return await _context.Cursos.AsNoTracking().Include(c => c.Aulas).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AdicionarAsync(Curso curso)
    {
        await _context.Cursos.AddAsync(curso);
    }

    public async Task AdicionarAulaAsync(Aula aula)
    {
        await _context.Aulas.AddAsync(aula);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
