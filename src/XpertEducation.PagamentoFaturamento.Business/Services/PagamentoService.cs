using XpertEducation.PagamentoFaturamento.Business.Enums;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Business.Services;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
    private readonly IPagamentoRepository _pagamentoRepository;

    public PagamentoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade,
                            IPagamentoRepository pagamentoRepository)
    {
        _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
        _pagamentoRepository = pagamentoRepository;
    }

    public async Task<Transacao> RealizarPagamento(PagamentoPedido pagamentoPedido)
    {
        var pedido = new Pedido
        {
            Id = pagamentoPedido.PedidoId,
            Valor = pagamentoPedido.Total
        };

        var pagamento = new Pagamento
        {
            Valor = pagamentoPedido.Total,
            DadosCartao = pagamentoPedido.DadosCartao,
            PedidoId = pagamentoPedido.PedidoId
        };

        var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(pedido, pagamento);

        if (transacao.StatusTransacao == StatusTransacao.Pago)
        {
            //pagamento.AdicionarEvento(new PagamentoRealizadoEvent(pedido.Id, pagamentoPedido.ClienteId, transacao.PagamentoId, transacao.Id, pedido.Valor));

            _pagamentoRepository.Adicionar(pagamento);
            _pagamentoRepository.AdicionarTransacao(transacao);

            await _pagamentoRepository.UnitOfWork.Commit();
            return transacao;
        }

        //await _mediatorHandler.PublicarNotificacao(new DomainNotification("pagamento", "A operadora recusou o pagamento"));
        //await _mediatorHandler.PublicarEvento(new PagamentoRecusadoEvent(pedido.Id, pagamentoPedido.ClienteId, transacao.PagamentoId, transacao.Id, pedido.Valor));

        return transacao;
    }
}
