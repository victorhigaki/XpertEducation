using XpertEducation.Core.Messages;

namespace XpertEducation.Core.Communication.Mediator;

public interface IMediatorHandler
{
    Task<bool> EnviarComando<T>(T command) where T : Command;
    Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
}
