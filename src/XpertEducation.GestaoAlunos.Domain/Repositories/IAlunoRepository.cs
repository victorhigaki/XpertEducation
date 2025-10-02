using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Domain.Repositories;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task Adicionar(Aluno aluno);
    Task AdicionarMatriculaAsync(Matricula matricula);
    Task<Matricula?> ObterMatriculaPorIdAsync(Guid matriculaId);
}
