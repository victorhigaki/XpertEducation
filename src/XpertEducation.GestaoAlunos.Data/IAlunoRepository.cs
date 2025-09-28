using XpertEducation.Core.Data;
using XpertEducation.GestaoAlunos.Domain;

namespace XpertEducation.GestaoAlunos.Data;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task Adicionar(Aluno aluno);
}
