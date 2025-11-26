using Moq;
using Moq.AutoMock;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.PagamentoFaturamento.Business.Enums;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Models;
using XpertEducation.PagamentoFaturamento.Business.Services;

namespace XpertEducation.PagamentoFaturamento.Business.Tests
{
    public class PagamentoServiceTests
    {
        [Fact(DisplayName = "RealizarPagamento")]
        [Trait("Categoria", "PagamentoFaturamento - PagamentoService")]
        public async Task PagamentoService_RealizarPagamento_DeveRealizarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();

            mocker.GetMock<IPagamentoRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            var pagamentoCartaoCreditoFacade = mocker.GetMock<IPagamentoCartaoCreditoFacade>();
            pagamentoCartaoCreditoFacade.Setup(r => r.RealizarPagamento(It.IsAny<Matricula>(), It.IsAny<Pagamento>())).Returns(new Transacao { PedidoId = Guid.NewGuid(), Valor = 100, StatusTransacao = StatusTransacao.Pago });

            var pagamentoRepository = mocker.GetMock<IPagamentoRepository>();
            var mediatorHandler = mocker.GetMock<IMediatorHandler>();

            var pagamentoService = mocker.CreateInstance<PagamentoService>();

            var pagamentoPedido = new PagamentoPedido
            {
                MatriculaId = Guid.NewGuid(),
                ClienteId = Guid.NewGuid(),
                Valor = 100,
                DadosCartao = new DadosCartao
                {
                    Nome = "Teste",
                    Numero = "4111111111111111",
                    Expiracao = "12/25",
                    Cvv = "123"
                }
            };

            // Act
            var transacao = await pagamentoService.RealizarPagamento(pagamentoPedido);

            // Assert
            mocker.GetMock<IPagamentoRepository>().Verify(r => r.Adicionar(It.IsAny<Pagamento>()), Times.Once);
        }
    }
}
