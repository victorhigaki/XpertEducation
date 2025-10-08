﻿using XpertEducation.Core.Messages.IntegrationEvents;

namespace XpertEducation.Core.Messages.NewFolder;

public class ConfirmadoEvent : IntegrationEvent
{
    public Guid PedidoId { get; private set; }
    public Guid ClienteId { get; private set; }
    public decimal Total { get; private set; }
    public string NomeCartao { get; private set; }
    public string NumeroCartao { get; private set; }
    public string ExpiracaoCartao { get; private set; }
    public string CvvCartao { get; private set; }

    public ConfirmadoEvent(Guid pedidoId, Guid clienteId, decimal total, string nomeCartao, string numeroCartao, string expiracaoCartao, string cvvCartao)
    {
        AggregateId = pedidoId;
        PedidoId = pedidoId;
        ClienteId = clienteId;
        Total = total;
        NomeCartao = nomeCartao;
        NumeroCartao = numeroCartao;
        ExpiracaoCartao = expiracaoCartao;
        CvvCartao = cvvCartao;
    }
}
