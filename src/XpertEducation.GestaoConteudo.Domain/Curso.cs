using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Curso : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public string ConteudoProgramatico { get; private set; }

    public ICollection<Aula> Aulas { get; set; }

    public Curso() { }

    public Curso(string nome, string conteudoProgramatico)
    {
        Nome = nome;
        ConteudoProgramatico = conteudoProgramatico;

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        Validacoes.ValidarSeVazio(ConteudoProgramatico, "O campo Nome não pode estar vazio");
    }
}
