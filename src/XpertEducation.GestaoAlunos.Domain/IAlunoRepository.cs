using XpertEducation.Core.Data;

namespace XpertEducation.GestaoAlunos.Domain;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task Adicionar(Aluno aluno);
}
