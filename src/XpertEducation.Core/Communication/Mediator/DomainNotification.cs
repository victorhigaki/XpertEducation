using MediatR;
using XpertEducation.Core.Messages;

namespace XpertEducation.Core.Communication.Mediator;

public class DomainNotification : Message, INotification
{
    public string Key { get; private set; }
    public string Value { get; private set; }

    public DomainNotification(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
