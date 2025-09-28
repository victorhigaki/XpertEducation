using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoAlunos.Domain;

public class Aluno : Entity, IAggregateRoot
{
    public Guid Id { get; private set; }
    public ICollection<Matricula> Matriculas { get; set; }
    public DateTime DataCadastro { get; set; }

    public Aluno(Guid id)
    {
        Id = id;
    }
}
