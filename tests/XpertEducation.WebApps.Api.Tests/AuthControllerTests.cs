using System.Net.Http.Json;
using XpertEducation.WebApps.Api.Models;
using XpertEducation.WebApps.Api.Tests.Config;

namespace XpertEducation.WebApps.Api.Tests;

[TestCaseOrderer("XpertEducation.WebApps.Api.Tests.Config.PriorityOrderer", "XpertEducation.WebApps.Api.Tests.Config")]
[Collection(nameof(IntegrationTestsFixtureCollection))]
public class AuthControllerTests
{
    private readonly IntegrationTestsFixture<Program> _testsFixture;

    public AuthControllerTests(IntegrationTestsFixture<Program> testsFixture)
    {
        _testsFixture = testsFixture;
    }

    [Fact(DisplayName = "Registrar um Usuário Válido"), TestPriority(1)]
    [Trait("Categoria", "Integração API - Auth")]
    public async Task AuthController_Register_DeveRetornarSucesso()
    {
        // Arrange
        var registerUserViewModel = new RegisterUserViewModel
        {
            Email = "Teste2@Teste.com",
            Password = "Teste2@123"
        };

        // Act
        var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/auth/registrar", registerUserViewModel);

        // Assert
        postResponse.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "Fazer um Login de Usuário Válido"), TestPriority(2)]
    [Trait("Categoria", "Integração API - Auth")]
    public async Task AuthController_Login_DeveRetornarSucesso()
    {
        // Arrange
        var loginUserViewModel = new LoginUserViewModel
        {
            Email = "Teste@Teste.com",
            Password = "Teste@123"
        };

        // Act
        var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/auth/login", loginUserViewModel);

        // Assert
        postResponse.EnsureSuccessStatusCode();
    }
}