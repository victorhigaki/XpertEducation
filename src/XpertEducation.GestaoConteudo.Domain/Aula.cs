using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Aula : Entity
{
    public string Titulo { get; private set; }
    public string ConteudoAula { get; private set; }
    public string Material { get; private set; }

    public Guid CursoId { get; private set; }
    public Curso Curso { get; private set; }

    public Aula() { }

    public Aula(Guid cursoId, string titulo, string conteudoAula, string material = null)
    {
        CursoId = cursoId;
        Titulo = titulo;
        ConteudoAula = conteudoAula;

        if (material is not null)
            Material = material;

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "Deve selecionar um Curso");
        Validacoes.ValidarSeVazio(Titulo, "O campo Titulo não pode estar vazio");
        Validacoes.ValidarSeVazio(ConteudoAula, "O campo Conteúdo da Aula não pode estar vazio");
    }
}
