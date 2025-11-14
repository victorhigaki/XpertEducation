using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Domain.Tests
{
    public class MatriculaTests
    {
        [Fact(DisplayName = "Adicionar Item Nova Matricula")]
        [Trait("Categoria", "Matricula Tests")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            // Arrange
            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();

            // Act
            var matricula = Matricula.MatriculaFactory.NovaMatricula(alunoId, cursoId);

            // Assert
            Assert.Equal(cursoId, matricula.CursoId);
            Assert.Equal(alunoId, matricula.AlunoId);
        }
    }
}
