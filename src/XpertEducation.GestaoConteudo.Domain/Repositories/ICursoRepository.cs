using XpertEducation.Core.Data;

namespace XpertEducation.GestaoConteudo.Domain.Repositories;

public interface ICursoRepository : IRepository<Curso>
{
    IEnumerable<Curso> ObterTodos();
    Curso ObterPorId(Guid cursoId);
    void Adicionar(Curso curso);

    void AdicionarAula(Aula aula);
}
