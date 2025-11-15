using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain.Tests
{
    public class AulaTests
    {
        [Fact(DisplayName = "Validar Aula Valido")]
        [Trait("Categoria", "Aula Tests")]
        public void Aula_DeveCriarAula_DeveEstarValido()
        {
            // Arrange
            var curso = new Curso("Curso Teste", "Conteudo Teste", 1000);

            //Act
            var aula = new Aula(curso.Id, "Aula 1", "Conteudo 1");

            // Assert
            Assert.Equal("Aula 1", aula.Titulo);
        }

        [Fact(DisplayName = "Validar Aula Inválido")]
        [Trait("Categoria", "Aula Tests")]
        public void Aula_DeveCriarAula_DeveEstarInvalido()
        {
            // Arrange
            var curso = new Curso("Curso Teste", "Conteudo Teste", 1000);

            // Act Assert
            Assert.Throws<DomainException>(() => new Aula(Guid.Empty, "Aula 1", "Conteudo 1"));
            Assert.Throws<DomainException>(() => new Aula(curso.Id, "", "Conteudo 1"));
            Assert.Throws<DomainException>(() => new Aula(curso.Id, "Aula 1", ""));
        }
    }
}
