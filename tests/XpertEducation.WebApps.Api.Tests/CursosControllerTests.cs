using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;
using System.Text.Json;
using XpertEducation.GestaoConteudo.Application.ViewModels;
using XpertEducation.WebApps.Api.Models;
using XpertEducation.WebApps.Api.Tests.Config;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
}
