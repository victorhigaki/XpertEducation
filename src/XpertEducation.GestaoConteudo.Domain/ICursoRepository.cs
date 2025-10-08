using XpertEducation.Core.Data;

namespace XpertEducation.GestaoConteudo.Domain;

public interface ICursoRepository : IRepository<Curso>
{
    Task<IEnumerable<Curso>> ObterTodosAsync();
    Task<Curso?> ObterPorIdAsync(Guid cursoId);
    Task AdicionarAsync(Curso curso);

    Task AdicionarAulaAsync(Aula aula);
}
