using XpertEducation.Core.Data;

namespace XpertEducation.GestaoConteudo.Domain;

public interface ICursoRepository : IRepository<Curso>
{
    IEnumerable<Curso> ObterTodos();
    Curso ObterPorId(Guid cursoId);
    void Adicionar(Curso curso);

    void AdicionarAula(Aula aula);
}
