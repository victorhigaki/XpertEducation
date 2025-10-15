using FluentValidation;
using FluentValidation.Results;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class MatriculaFinalizarCursoCommand : Command
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }

    public MatriculaFinalizarCursoCommand(Guid matriculaId, Guid alunoId, Guid cursoId)
    {
        MatriculaId = matriculaId;
        AlunoId = alunoId;
        CursoId = cursoId;
    }

    public override bool EhValido()
    {
        ValidationResult = new MatriculaFinalizarCursoValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class MatriculaFinalizarCursoValidation : AbstractValidator<MatriculaFinalizarCursoCommand>
{
    public MatriculaFinalizarCursoValidation()
    {
        RuleFor(c => c.MatriculaId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id da Matricula inválido");

        RuleFor(c => c.CursoId)
            .NotEqual(Guid.Empty)
            .WithMessage("Id do Curso inválida");
    }
}
