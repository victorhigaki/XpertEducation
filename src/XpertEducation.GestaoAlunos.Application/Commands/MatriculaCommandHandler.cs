using MediatR;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages;
using XpertEducation.GestaoAlunos.Application.Events;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.Commands;
public class MatriculaCommandHandler :
    IRequestHandler<AdicionarAlunoCursoCommand, bool>
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoRepository _alunoRepository;

    public MatriculaCommandHandler(IMediatorHandler mediatorHandler, 
                                   IAlunoRepository alunoRepository)
    {
        _mediatorHandler = mediatorHandler;
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(AdicionarAlunoCursoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;
        var matricula = new Matricula(message.AlunoId, message.CursoId, message.CursoNome);
        await _alunoRepository.AdicionarMatriculaAsync(matricula);
        //matricula.AdicionarEvento(new MatriculaRealizadaEvent(matricula.Id, matricula.CursoId, matricula.AlunoId, matricula.CursoNome, matricula.Status));
        return await _alunoRepository.UnitOfWork.Commit();
    }

    private bool ValidarComando(Command message)
    {
        if (message.EhValido()) return true;

        foreach (var error in message.ValidationResult.Errors)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        return false;
    }
}