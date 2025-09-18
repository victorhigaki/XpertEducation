using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoAlunos.Domain;

public class Aluno : Entity, IAggregateRoot
{
    public ICollection<Matricula> Matriculas { get; set; }
}
