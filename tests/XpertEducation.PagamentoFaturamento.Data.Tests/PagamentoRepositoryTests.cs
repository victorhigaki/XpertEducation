using Microsoft.EntityFrameworkCore;
using Moq;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.PagamentoFaturamento.Business.Models;
using XpertEducation.PagamentoFaturamento.Data.Repositories;

namespace XpertEducation.PagamentoFaturamento.Data.Tests;

public class PagamentoRepositoryTests
{
    [Fact(DisplayName = "Adicionar Aula Válido")]
    [Trait("Categoria", "PagamentoRepository - Cursos")]
    public void PagamentoRepository_()
    {
        // Arrange
        var pagamento = new Pagamento
        {
            PedidoId = Guid.NewGuid(),
            Valor = 150.00m,
            DadosCartao = new DadosCartao
            {
                Nome = "Teste Teste",
                Numero = "1234567890123456",
                Expiracao = "12/25",
                Cvv = "123"
            },
        };

        var mockSet = new Mock<DbSet<Pagamento>>();
        var mockContext = new Mock<PagamentoContext>(new Mock<DbContextOptions<PagamentoContext>>(), new Mock<IMediatorHandler>());
        mockContext.Setup(m => m.Pagamentos).Returns(mockSet.Object);

        var pagamentoRepository = new PagamentoRepository(mockContext.Object);

        // Act
        pagamentoRepository.Adicionar(pagamento);

        // Assert
        mockSet.Verify(m => m.Add(It.IsAny<Pagamento>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
}
