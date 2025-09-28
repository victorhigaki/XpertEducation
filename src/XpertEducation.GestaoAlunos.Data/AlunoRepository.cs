using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain;

namespace XpertEducation.GestaoAlunos.Data;

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

    public void Dispose()
    {
        _context.Dispose();
    }
}

