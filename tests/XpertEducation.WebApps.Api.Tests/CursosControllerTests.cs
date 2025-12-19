using System.Net.Http.Json;
using System.Text.Json;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.WebApps.Api.Models;
using XpertEducation.WebApps.Api.Tests.Config;

namespace XpertEducation.WebApps.Api.Tests;

[Collection(nameof(IntegrationTestsFixtureCollection))]
public class CursosControllerTests
{
    private readonly IntegrationTestsFixture<Program> _testsFixture;

    public CursosControllerTests(IntegrationTestsFixture<Program> testsFixture)
    {
        _testsFixture = testsFixture;
    }

    [Fact(DisplayName = "Adicionar Curso Válido")]
    [Trait("Categoria", "Integração API - Cursos")]
    public async Task CursosController_AdicionarCurso_DeveRetornarSucesso()
    {
        // Arrange
        var curso = new CursoViewModel
        {
            Id = new Guid("d290f1ee-6c54-4b01-90e6-d701748f0851"),
            Nome = "Curso Teste",
            Valor = 100,
            Aulas = new List<AulaViewModel>
            {
            },
            ConteudoProgramatico = new ConteudoProgramaticoViewModel
            {
                Objetivo = "Objetivo Teste",
                Conteudo = "Conteudo Teste",
                Metodologia = "Metodologia Teste",
                Bibliografia = "Bibliografia Teste",
            }
        };

        await _testsFixture.RealizarLoginApi();

        var result = JsonSerializer.Deserialize<CustomResponseViewModel>(_testsFixture.UsuarioToken);

        _testsFixture.Client.AtribuirToken(result.Data.ToString());

        // Act
        var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/cursos", curso);

        // Assert
        postResponse.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "Adicionar Curso Inválido")]
    [Trait("Categoria", "Integração API - Cursos")]
    public async Task CursosController_AdicionarCurso_DeveRetornarErro()
    {
        // Arrange
        var curso = new CursoViewModel
        {
            Nome = "",
            Valor = 0,
            ConteudoProgramatico = new ConteudoProgramaticoViewModel
            {
                Objetivo = "",
                Conteudo = "",
                Metodologia = "",
                Bibliografia = "",
            }
        };

        await _testsFixture.RealizarLoginApi();


        var result = JsonSerializer.Deserialize<CustomResponseViewModel>(_testsFixture.UsuarioToken);

        _testsFixture.Client.AtribuirToken(result.Data.ToString());

        // Act
        var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/cursos", curso);

        // Assert
        postResponse.StatusCode.Equals(400);
    }
}
