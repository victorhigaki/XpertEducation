using FluentValidation;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;
public class AdicionarAlunoCursoCommand : Command
{
    public Guid AlunoId { get; private set; }
    public Guid CursoId { get; private set; }
    public string CursoNome { get; private set; }

    public AdicionarAlunoCursoCommand(Guid alunoId, Guid cursoId, string nomeCurso)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
        CursoNome = nomeCurso;
    }

    public override bool EhValido()
    {
        ValidationResult = new AdicionarAlunoCursoValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class AdicionarAlunoCursoValidation : AbstractValidator<AdicionarAlunoCursoCommand>
{
    public AdicionarAlunoCursoValidation()
    {
        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do aluno não pode ser vazio.");
        RuleFor(c => c.CursoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do curso não pode ser vazio.");
        RuleFor(c => c.CursoNome)
            .NotEqual(string.Empty)
            .WithMessage("O Nome do curso não pode ser vazio.");
    }
}
