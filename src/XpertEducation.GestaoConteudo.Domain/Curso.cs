using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain
{
    public class Curso : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public ConteudoProgramatico ConteudoProgramatico { get; private set; }

        public Curso()
        {
        }

        public Curso(string nome, ConteudoProgramatico conteudoProgramatico)
        {
            Nome = nome;
            ConteudoProgramatico = conteudoProgramatico;
            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
        }
    }
}
