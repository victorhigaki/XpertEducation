using Moq;
using Moq.AutoMock;
using XpertEducation.PagamentoFaturamento.Business.Enums;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.AntiCorruption.Tests;

public class PagamentoCartaoCreditoFacadeTests
{
    [Fact(DisplayName = "RealizarPagamento")]
    [Trait("Categoria", "PagamentoFaturamento - PagamentoCartaoCreditoFacade")]
    public async Task PagamentoCartaoCreditoFacade_RealizarPagamento_DeveRealizarComSucesso()
    {
        // Arrange
        var mocker = new AutoMocker();
        var pagamentoCartaoCreditoFacade = mocker.CreateInstance<PagamentoCartaoCreditoFacade>();
        var matricula = new Matricula
        {
            Id = Guid.NewGuid()
        };
        var pagamento = new Pagamento
        {
            Valor = 1000,
            DadosCartao = new DadosCartao
            {
                Numero = "4111111111111111"
            }
        };

        var configManager = mocker.GetMock<IConfigurationManager>();
        var apiKey = "apiKey";
        configManager.Setup(x => x.GetValue("apiKey")).Returns(apiKey);
        var encriptionKey = "encriptionKey";
        configManager.Setup(x => x.GetValue("encriptionKey")).Returns(encriptionKey);

        var payPalGateway = mocker.GetMock<IPayPalGateway>();
        var serviceKey = "serviceKey";
        payPalGateway.Setup(x => x.GetPayPalServiceKey(apiKey, encriptionKey)).Returns(serviceKey);
        var cardHashKey = "cardHashKey";
        payPalGateway.Setup(x => x.GetCardHashKey(serviceKey, It.IsAny<string>())).Returns(cardHashKey);
        //var orderId = "1234";
        payPalGateway.Setup(x => x.CommitTransaction(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);

        // Act
        var transacao = pagamentoCartaoCreditoFacade.RealizarPagamento(matricula, pagamento);

        // Assert
        Assert.Equal(StatusTransacao.Pago, transacao.StatusTransacao);
    }
}
