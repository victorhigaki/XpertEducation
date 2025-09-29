using Microsoft.AspNetCore.Mvc;
using XpertEducation.Core.Notifications;

namespace XpertEducation.WebApps.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private readonly INotifications _notifications;

    public BaseController(INotifications notifications)
    {
        _notifications = notifications;
    }

    public ActionResult CustomResponse(object result = null)
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
            errors = _notifications.ObterNotificacoes().Select(n => n.Mensagem)
        });
    }

    protected bool OperacaoValida()
    {
        return !_notifications.TemNotificacao();
    }
}
