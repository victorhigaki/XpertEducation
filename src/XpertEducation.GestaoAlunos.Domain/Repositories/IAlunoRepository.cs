using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Domain.Repositories;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task Adicionar(Aluno aluno);
    Task<Matricula?> ObterMatriculaPorAlunoId(Guid matriculaId);
    void AdicionarMatricula(Matricula matricula);
    void AtualizarMatricula(Matricula matricula);
}
