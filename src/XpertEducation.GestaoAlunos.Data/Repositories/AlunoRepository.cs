using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Data.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly AlunosContext _context;

    public AlunoRepository(AlunosContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task Adicionar(Aluno aluno)
    {
        await _context.Alunos.AddAsync(aluno);
    }

    public async Task AdicionarMatriculaAsync(Matricula matricula)
    {
        await _context.Matriculas.AddAsync(matricula);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task<Matricula?> ObterMatriculaPorIdAsync(Guid matriculaId)
    {
        throw new NotImplementedException();
    }
}

