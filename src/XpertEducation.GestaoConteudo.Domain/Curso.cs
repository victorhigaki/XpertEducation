using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Curso : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public ConteudoProgramatico ConteudoProgramatico { get; private set; }
    public decimal Valor { get; private set; }

    public ICollection<Aula> Aulas { get; private set; }

    public Curso() { }

    public Curso(string nome, ConteudoProgramatico conteudoProgramatico, decimal valor)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        ConteudoProgramatico = conteudoProgramatico;
        Valor = valor;
        Aulas = new List<Aula>();

        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor não pode ser menor que 1");
    }
}
