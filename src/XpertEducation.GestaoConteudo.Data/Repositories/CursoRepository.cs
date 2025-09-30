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

    public async Task<Curso?> ObterCursoPorId(Guid id)
    {
        return await _context.Cursos.FindAsync(id);
    }

    public async Task AdicionarCursoAsync(Curso curso)
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
