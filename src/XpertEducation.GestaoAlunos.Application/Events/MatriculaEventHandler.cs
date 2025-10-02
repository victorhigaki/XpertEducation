using MediatR;
using XpertEducation.Core.Communication.Mediator;

namespace XpertEducation.GestaoAlunos.Application.Events;

public class MatriculaEventHandler :
    INotificationHandler<MatriculaRealizadaEvent>
{
    private readonly IMediatorHandler _mediatorHandler;

    public MatriculaEventHandler(IMediatorHandler mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    public Task Handle(MatriculaRealizadaEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}