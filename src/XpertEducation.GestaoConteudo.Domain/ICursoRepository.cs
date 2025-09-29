using XpertEducation.Core.Data;

namespace XpertEducation.GestaoConteudo.Domain;

public interface ICursoRepository : IRepository<Curso>
{
    Task AdicionarCursoAsync(Curso curso);
    Task AdicionarAulaAsync(Aula aula);
}
