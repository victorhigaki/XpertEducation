using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using XpertEducation.WebApps.Api.Models;

namespace XpertEducation.WebApps.Api.Tests.Config;

[CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Program>>
{
    // A fixture será construída pelo xUnit e injetada aqui.
    public IntegrationTestsFixture<Program> TestsFixture { get; private set; }

}

public class IntegrationTestsFixture<Program> : IDisposable where Program : class
{

    public string UsuarioToken;

    public HttpClient Client;
    public readonly LojaAppFactory<Program> Factory;

    public IntegrationTestsFixture()
    {
        var clientOptions = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            BaseAddress = new Uri("http://localhost"),
            HandleCookies = true,
            MaxAutomaticRedirections = 7
        };

        Factory = new LojaAppFactory<Program>();
        Client = Factory.CreateClient();
    }

    public async Task RealizarLoginApi()
    {
        var loginUser = new LoginUserViewModel
        {
            Email = "admin@xpert.com",
            Password = "Teste@12345"
        };

        // Recriando o client para evitar configurações de Web
        Client = Factory.CreateClient();

        var response = await Client.PostAsJsonAsync("api/auth/login", loginUser);
        response.EnsureSuccessStatusCode();
        UsuarioToken = await response.Content.ReadAsStringAsync();
    }

    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
    }
}
