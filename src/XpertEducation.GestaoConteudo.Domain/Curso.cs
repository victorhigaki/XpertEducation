using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain
{
    internal class Curso : Entity, IAggregateRoot
    {
        public Curso()
        {
        }

        public ICollection<Aula> Aulas { get; set; }
    }
}
