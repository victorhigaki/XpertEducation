namespace XpertEducation.PagamentoFaturamento.AntiCorruption.Tests;

public class PayPalGatewayTests
{
    private readonly PayPalGateway _payPalGateway;

    public PayPalGatewayTests()
    {
        _payPalGateway = new PayPalGateway();
    }

    [Fact(DisplayName = "CommitTransaction")]
    [Trait("Categoria", "PagamentoFaturamento - PayPalGateway")]
    public void PayPalGateway_CommitTransaction_DeveRetornarTrueOuFalse()
    {
        // Arrange

        string cardHashKey = "cardHashKey";
        string orderId = "orderId";
        decimal amount = 100m;

        // Act
        var result = _payPalGateway.CommitTransaction(cardHashKey, orderId, amount);

        // Assert
        Assert.IsType<bool>(result);
    }

    [Fact(DisplayName = "GetCardHashKey")]
    [Trait("Categoria", "PagamentoFaturamento - PayPalGateway")]
    public void PayPalGateway_GetCardHashKey_ShouldReturnString()
    {
        // Arrange
        string serviceKey = "serviceKey";
        string cartaoCredito = "cartaoCredito";

        // Act
        var result = _payPalGateway.GetCardHashKey(serviceKey, cartaoCredito);

        // Assert
        Assert.IsType<string>(result);
    }

    [Fact(DisplayName = "GetPayPalServiceKey")]
    [Trait("Categoria", "PagamentoFaturamento - PayPalGateway")]
    public void PayPalGateway_GetPayPalServiceKey_ShouldReturnString()
    {
        // Arrange
        string apiKey = "apiKey";
        string encriptionKey = "encriptionKey";

        // Act
        var result = _payPalGateway.GetPayPalServiceKey(apiKey, encriptionKey);

        // Assert
        Assert.IsType<string>(result);
    }
}
