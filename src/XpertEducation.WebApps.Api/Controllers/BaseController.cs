using MediatR;
using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Communication.Mediator;
using XpertEducation.Core.Messages.Notifications;
using XpertEducation.WebApps.Api.Extensions;

namespace XpertEducation.WebApps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private readonly DomainNotificationHandler _notifications;
    private readonly IMediatorHandler _mediatorHandler;

    protected Guid UserId { get; private set; }

    protected BaseController(INotificationHandler<DomainNotification> notifications,
                             IMediatorHandler mediatorHandler,
                             IAppIdentityUser appIdentityUser)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediatorHandler = mediatorHandler;
        UserId = appIdentityUser.GetUserId();
    }

    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = ObterMensagensErro()
        });
    }

    protected bool OperacaoValida()
    {
        return !_notifications.TemNotificacao();
    }

    protected IEnumerable<string> ObterMensagensErro()
    {
        return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
    }

    protected void NotificarErro(string codigo, string mensagem)
    {
        _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
    }
}
