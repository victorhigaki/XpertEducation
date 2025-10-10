using XpertEducation.Core.Messages;

namespace XpertEducation.GestaoAlunos.Application.Events;

public class MatriculaPagamentoEvent : Event
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }
    public decimal ValorTotal { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }

    public MatriculaPagamentoEvent(Guid matriculaId, Guid alunoId, decimal valorTotal, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        AlunoId = alunoId;
        ValorTotal = valorTotal;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }
}
