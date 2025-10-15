using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages.IntegrationEvents;
using XpertEducation.PagamentoFaturamento.Business.Enums;
using XpertEducation.PagamentoFaturamento.Business.Interfaces;
using XpertEducation.PagamentoFaturamento.Business.Models;

namespace XpertEducation.PagamentoFaturamento.Business.Services;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
    private readonly IPagamentoRepository _pagamentoRepository;
    private readonly IMediatorHandler _mediatorHandler;

    public PagamentoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade,
                            IPagamentoRepository pagamentoRepository,
                            IMediatorHandler mediatorHandler)
    {
        _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
        _pagamentoRepository = pagamentoRepository;
        _mediatorHandler = mediatorHandler;
    }

    public async Task<Transacao> RealizarPagamento(PagamentoPedido pagamentoPedido)
    {
        var matricula = new Matricula
        {
            Id = pagamentoPedido.MatriculaId,
            Valor = pagamentoPedido.Valor
        };

        var pagamento = new Pagamento
        {
            PedidoId = pagamentoPedido.MatriculaId,
            Valor = pagamentoPedido.Valor,
            DadosCartao = pagamentoPedido.DadosCartao,
        };

        var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(matricula, pagamento);

        if (transacao.StatusTransacao == StatusTransacao.Pago)
        {
            _pagamentoRepository.Adicionar(pagamento);
            _pagamentoRepository.AdicionarTransacao(transacao);

            pagamento.AdicionarEvento(new MatriculaPagamentoRealizadoEvent(matricula.Id, pagamentoPedido.ClienteId, transacao.PagamentoId, transacao.Id, matricula.Valor));

            await _pagamentoRepository.UnitOfWork.Commit();
            return transacao;
        }

        await _mediatorHandler.PublicarNotificacao(new DomainNotification("pagamento", "A operadora recusou o pagamento"));
        await _mediatorHandler.PublicarEvento(new MatriculaPagamentoRecusadoEvent(matricula.Id, pagamentoPedido.ClienteId, transacao.PagamentoId, transacao.Id, matricula.Valor));

        return transacao;
    }
}
