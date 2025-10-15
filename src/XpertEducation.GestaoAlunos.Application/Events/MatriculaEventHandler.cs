using MediatR;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages.IntegrationEvents;
using XpertEducation.GestaoAlunos.Application.Commands;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.Events;

public class MatriculaEventHandler : INotificationHandler<MatriculaCriadaEvent>,
    INotificationHandler<MatriculaPagamentoEvent>,
    INotificationHandler<MatriculaPagamentoRealizadoEvent>,
    INotificationHandler<MatriculaPagamentoRecusadoEvent>
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoRepository _alunoRepository;

    public MatriculaEventHandler(IMediatorHandler mediatorHandler, IAlunoRepository alunoRepository)
    {
        _mediatorHandler = mediatorHandler;
        _alunoRepository = alunoRepository;
    }

    public Task Handle(MatriculaCriadaEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(MatriculaPagamentoEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(MatriculaPagamentoRealizadoEvent message, CancellationToken cancellationToken)
    {
        //await _mediatorHandler.EnviarComando(new FinalizarPedidoCommand(message.MatriculaId, message.AlunoId));
        return Task.CompletedTask;
    }

    public async Task Handle(MatriculaPagamentoRecusadoEvent message, CancellationToken cancellationToken)
    {
        await _mediatorHandler.EnviarComando(new MatriculaPagamentoRecusadoCommand(matriculaId: message.MatriculaId, alunoId: message.AlunoId));
    }
}