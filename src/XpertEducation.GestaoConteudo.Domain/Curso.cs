using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain;

public class Curso : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public Guid AulaId { get; set; }

    public ConteudoProgramatico ConteudoProgramatico { get; private set; }
    public Aula Aula { get; private set; }

    public Curso() { }

    public Curso(string nome, Guid aulaId)
    {
        Nome = nome;
        AulaId = aulaId;
        Validar();
    }

    public void AlterarAula(Aula aula)
    {
        Aula = aula;
        AulaId = aula.Id;
    }

    private void Validar()
    {
        Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        Validacoes.ValidarSeIgual(AulaId, Guid.Empty, "O campo AulaId do produto não pode estar vazio");
    }
}
