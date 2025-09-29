using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Aula : Entity
{
    public string Titulo { get; private set; }
    public string ConteudoAula { get; private set; }
    public string Material { get; private set; }

    public ICollection<Curso> Cursos { get; set; }

    public Aula() { }

    public Aula(string titulo, string conteudoAula, string material)
    {
        Titulo = titulo;
        ConteudoAula = conteudoAula;
        Material = material;

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Titulo, "O campo Titulo não pode estar vazio");
        Validacoes.ValidarSeVazio(ConteudoAula, "O campo Conteúdo da Aula não pode estar vazio");
        Validacoes.ValidarSeVazio(Material, "O campo Material não pode estar vazio");
    }
}
