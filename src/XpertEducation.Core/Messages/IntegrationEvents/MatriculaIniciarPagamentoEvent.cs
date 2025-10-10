﻿namespace XpertEducation.Core.Messages.IntegrationEvents;

public class MatriculaIniciarPagamentoEvent : IntegrationEvent
{
    public Guid MatriculaId { get; private set; }
    public Guid AlunoId { get; private set; }
    public decimal Valor { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }

    public MatriculaIniciarPagamentoEvent(Guid matriculaId, Guid alunoId, decimal valor, 
        string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AggregateId = matriculaId;
        MatriculaId = matriculaId;
        AlunoId = alunoId;
        Valor = valor;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }
}
