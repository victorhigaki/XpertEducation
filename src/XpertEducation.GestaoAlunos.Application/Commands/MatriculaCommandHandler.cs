using MediatR;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages;
using XpertEducation.Core.Messages.IntegrationEvents;
using XpertEducation.GestaoAlunos.Application.Events;
using XpertEducation.GestaoAlunos.Domain.Models;
using XpertEducation.GestaoAlunos.Domain.Repositories;

namespace XpertEducation.GestaoAlunos.Application.Commands;
public class MatriculaCommandHandler :
    IRequestHandler<MatriculaAlunoCommand, bool>,
    IRequestHandler<MatriculaIniciarPagamentoCommand, bool>,
    IRequestHandler<MatriculaFinalizarPagamentoCommand, bool>
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IAlunoRepository _alunoRepository;

    public MatriculaCommandHandler(IMediatorHandler mediatorHandler,
                                   IAlunoRepository alunoRepository)
    {
        _mediatorHandler = mediatorHandler;
        _alunoRepository = alunoRepository;
    }

    public async Task<bool> Handle(MatriculaAlunoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;

        Matricula matricula = await _alunoRepository.ObterMatriculaPorAlunoId(message.AlunoId);
        if (matricula == null)
        {
            matricula = Matricula.MatriculaFactory.NovaMatricula(message.AlunoId, message.CursoId);
            _alunoRepository.AdicionarMatricula(matricula);
            matricula.AdicionarEvento(new MatriculaCriadaEvent(matricula.Id, matricula.CursoId, matricula.AlunoId));
        }
        else
        {
            matricula.AlterarCurso(message.CursoId);
            _alunoRepository.AtualizarMatricula(matricula);
            matricula.AdicionarEvento(new MatriculaAtualizadaEvent(matricula.Id, matricula.CursoId, matricula.AlunoId));
        }

        return await _alunoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Handle(MatriculaIniciarPagamentoCommand message, CancellationToken cancellationToken)
    {
        if (!ValidarComando(message)) return false;

        var matricula = await _alunoRepository.ObterMatriculaPorAlunoId(message.AlunoId);

        if (matricula == null)
        {
            await _mediatorHandler.PublicarNotificacao(new DomainNotification("matricula", "Matricula não encontrada!"));
            return false;
        }

        matricula.Iniciar();

        await _mediatorHandler.PublicarEvento(new MatriculaIniciarPagamentoEvent(matricula.Id, matricula.AlunoId, matricula.Valor, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));

        _alunoRepository.AtualizarMatricula(matricula);
        return await _alunoRepository.UnitOfWork.Commit();
    }

    public async Task<bool> Handle(MatriculaFinalizarPagamentoCommand message, CancellationToken cancellationToken)
    {
        if (ValidarComando(message)) return false;

        var matricula = await _alunoRepository.ObterMatriculaPorAlunoId(message.AlunoId);

        if (matricula == null)
        {
            await _mediatorHandler.PublicarNotificacao(new DomainNotification("matricula", "Matrícula não encontrada!"));
            return false;
        }

        matricula.Finalizar();

        matricula.AdicionarEvento(new MatriculaPagamentoFinalizadoEvent(message.MatriculaId));
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