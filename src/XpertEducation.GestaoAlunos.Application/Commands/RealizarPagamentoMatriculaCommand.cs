using FluentValidation;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class RealizarPagamentoMatriculaCommand : Command
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }

    public RealizarPagamentoMatriculaCommand(Guid matriculaId, Guid alunoId)
    {
        MatriculaId = matriculaId;
        AlunoId = alunoId;
    }

    public override bool EhValido()
    {
        ValidationResult = new RealizarPagamentoMatriculaValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class RealizarPagamentoMatriculaValidation : AbstractValidator<RealizarPagamentoMatriculaCommand>
{
    public RealizarPagamentoMatriculaValidation()
    {
        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do aluno não pode ser vazio.");
        RuleFor(c => c.MatriculaId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id da matricula não pode ser vazio.");
    }
}
