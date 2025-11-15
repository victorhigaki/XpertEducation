using XpertEducation.GestaoAlunos.Domain.Models;

namespace XpertEducation.GestaoAlunos.Domain.Tests;

public class AlunoTests
{
    [Fact(DisplayName = "Aluno Valido")]
    [Trait("Categoria", "Aluno Tests")]
    public void Aluno_DeveCriarAluno_DeveEstarValido()
    {
        // Arrange 
        var alunoId = Guid.NewGuid();

        // Act
        var aluno = new Aluno(alunoId);

        // Assert
        Assert.Equal(alunoId, aluno.Id);
    }
}
