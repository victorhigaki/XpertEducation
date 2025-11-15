using XpertEducation.Core.DomainObjects;

namespace XpertEducation.GestaoConteudo.Domain.Tests;

public class CursoTests
{
    [Fact(DisplayName = "Validar Curso Valido")]
    [Trait("Categoria", "Curso Tests")]
    public void Curso_ValidarCurso_DeveEstarValido()
    {
        // Arrange Act
        var curso = new Curso("Teste", "Teste", 1000);

        // Assert
        Assert.Equal(1000, curso.Valor);
    }

    [Fact(DisplayName = "Validar Curso Invalido")]
    [Trait("Categoria", "Curso Tests")]
    public void Curso_ValidarCurso_DeveEstarInvalido()
    {
        // Arrange Act Assert
        Assert.Throws<DomainException>(() => new Curso("Teste", "Teste", 0));
        Assert.Throws<DomainException>(() => new Curso("", "Teste", 2));
        Assert.Throws<DomainException>(() => new Curso("Teste", "", 2));
    }
}
