using Microsoft.EntityFrameworkCore;
using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain;

namespace XpertEducation.GestaoAlunos.Data;

public class AlunosContext : DbContext, IUnitOfWork
{
    public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
