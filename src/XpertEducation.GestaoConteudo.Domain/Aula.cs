using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain
{
    public class Aula : Entity
    {
        public string Titulo { get; private set; }
        public string ConteudoAula { get; private set; }
        public string Material { get; private set; }
        public Guid CursoId { get; private set; }
        public Curso Curso { get; set; }

        public Aula()
        {

        }

        public Aula(string titulo, string conteudoAula, string material, Guid cursoId)
        {
            Titulo = titulo;
            ConteudoAula = conteudoAula;
            Material = material;
            CursoId = cursoId;

            Validar();
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Titulo, "O campo Titulo não pode estar vazio");
            Validacoes.ValidarSeVazio(ConteudoAula, "O campo Conteúdo da Aula não pode estar vazio");
            Validacoes.ValidarSeVazio(Material, "O campo Material não pode estar vazio");
            Validacoes.ValidarSeIgual(CursoId, Guid.Empty, "O campo CursoId não pode estar vazio");
        }
    }
}
