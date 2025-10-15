using FluentValidation;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class MatriculaRealizarAulaCommand : Command
{
    public Guid AlunoId { get; private set; }
    public Guid AulaId { get; private set; }

    public MatriculaRealizarAulaCommand(Guid userId, Guid aulaId)
    {
        AlunoId = userId;
        AulaId = aulaId;
    }

    public override bool EhValido()
    {
        ValidationResult = new RealizarAulaValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class RealizarAulaValidation : AbstractValidator<MatriculaRealizarAulaCommand>
{
    public RealizarAulaValidation()
    {
        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do Aluno inválido");

        RuleFor(c => c.AulaId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id da Aula inválida");
    }
}
