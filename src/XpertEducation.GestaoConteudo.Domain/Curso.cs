using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Curso : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public string ConteudoProgramatico { get; private set; }
    public decimal Valor { get; private set; }
    public ICollection<Aula> Aulas { get; set; }

    public Curso() { }

    public Curso(string nome, string conteudoProgramatico, decimal valor)
    {
        Nome = nome;
        ConteudoProgramatico = conteudoProgramatico;
        Valor = valor;
        Aulas = new List<Aula>();
        Validar();
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        Validacoes.ValidarSeVazio(ConteudoProgramatico, "O campo Nome não pode estar vazio");
        Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor não pode ser menor que 1");
    }

}
