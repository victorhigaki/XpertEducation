namespace XpertEducation.Core.Notifications;

public interface INotifications
{
    List<Notificacao> ObterNotificacoes();
    bool TemNotificacao();
}
