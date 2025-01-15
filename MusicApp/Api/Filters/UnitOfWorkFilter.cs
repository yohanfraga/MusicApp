using Microsoft.AspNetCore.Mvc.Filters;
using MusicApp.Api.Extensions;
using MusicApp.Infra.ORM.UnitOfWork.Interfaces;

namespace MusicApp.Api.Filters;

public sealed class  UnitOfWorkFilter(IUnitOfWork unitOfWork)
    : ActionFilterAttribute
{
    public override void OnActionExecuted(ActionExecutedContext actionExecuted)
    {
        if (actionExecuted.IsMethodGet()) return;
        
        if (Success(actionExecuted))
            unitOfWork.Commit();
        else
            unitOfWork.Rollback();

        base.OnActionExecuted(actionExecuted);
    }

    public override void OnActionExecuting(ActionExecutingContext actionExecuted)
    {
        if (actionExecuted.IsMethodGet()) return;

        unitOfWork.Begin();

        base.OnActionExecuting(actionExecuted);
    }
        
    private static bool Success(ActionExecutedContext actionExecuted) =>
        actionExecuted.Exception is null && actionExecuted.ModelState.IsValid;
}