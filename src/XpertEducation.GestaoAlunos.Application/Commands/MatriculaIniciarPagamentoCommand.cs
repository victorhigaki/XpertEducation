using FluentValidation;
using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Commands;

public class MatriculaIniciarPagamentoCommand : Command
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }

    public MatriculaIniciarPagamentoCommand(Guid matriculaId, Guid alunoId, 
        string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        MatriculaId = matriculaId;
        AlunoId = alunoId;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }

    public override bool EhValido()
    {
        ValidationResult = new RealizarPagamentoMatriculaValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class RealizarPagamentoMatriculaValidation : AbstractValidator<MatriculaIniciarPagamentoCommand>
{
    public RealizarPagamentoMatriculaValidation()
    {
        RuleFor(c => c.AlunoId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id do aluno não pode ser vazio.");

        RuleFor(c => c.MatriculaId)
            .NotEqual(Guid.Empty)
            .WithMessage("O Id da matricula não pode ser vazio.");

        RuleFor(c => c.NomeCartao)
            .NotEqual(string.Empty)
            .WithMessage("O Nome do Cartão não pode ser vazio.");

        RuleFor(c => c.NumeroCartao)
            .NotEqual(string.Empty)
            .WithMessage("O Número do Cartão não pode ser vazio.");

        RuleFor(c => c.ExpiracaoCartao)
            .NotEqual(string.Empty)
            .WithMessage("A Data de Expiração do Cartão não pode ser vazio.");

        RuleFor(c => c.CvvCartao)
            .NotEqual(string.Empty)
            .WithMessage("O CVV do Cartão não pode ser vazio.");
    }
}
