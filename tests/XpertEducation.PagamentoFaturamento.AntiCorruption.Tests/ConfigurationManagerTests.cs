namespace XpertEducation.PagamentoFaturamento.AntiCorruption.Tests;

public class ConfigurationManagerTests
{
    [Fact(DisplayName = "GetValue")]
    [Trait("Categoria", "PagamentoFaturamento - ConfigurationManager")]
    public void ConfigurationManager_GetValue_ShouldReturnString()
    {
        // Arrange
        var configurationManager = new ConfigurationManager();
        string node = "someNode";

        // Act
        var result = configurationManager.GetValue(node);

        // Assert
        Assert.IsType<string>(result);
    }
}
