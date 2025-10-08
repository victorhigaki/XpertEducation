using FluentValidation;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class MatriculaAlunoCommand : Command
{
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }

    public MatriculaAlunoCommand(Guid alunoId, Guid cursoId)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
    }
    
    public override bool EhValido()
    {
        ValidationResult = new MatriculaAlunoValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class MatriculaAlunoValidation : AbstractValidator<MatriculaAlunoCommand>
{
    public MatriculaAlunoValidation()
    {
        RuleFor(c => c.CursoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do curso não pode ser vazio.");

        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do aluno não pode ser vazio.");
    }
}
