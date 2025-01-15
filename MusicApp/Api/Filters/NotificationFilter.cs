using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicApp.Api.Extensions;
using MusicApp.Domain.Handler.Notification.Interface;

namespace MusicApp.Api.Filters;

public sealed class  NotificationFilter(INotificationHandler notification)
    : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext actionExecuted)
    {
        if (!actionExecuted.IsMethodGet() && notification.HasNotification())
            actionExecuted.Result = new BadRequestObjectResult(notification.GetAllNotifications());

        base.OnActionExecuted(actionExecuted);
    }
}