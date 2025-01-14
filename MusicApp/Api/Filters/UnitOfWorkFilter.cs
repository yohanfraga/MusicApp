using Microsoft.AspNetCore.Mvc.Filters;
using MusicApp.Domain.Interfaces;

namespace MusicApp.Api.Filters;

public sealed class  UnitOfWorkFilter(IUnitOfWork unitOfWork)
    : ActionFilterAttribute
{
    private const string MethodGet = "GET";
    
    public override void OnActionExecuted(ActionExecutedContext actionExecuted)
    {
        if (IsMethodGet(actionExecuted)) return;
        
        if (Success(actionExecuted))
            unitOfWork.Commit();
        else
            unitOfWork.Rollback();

        base.OnActionExecuted(actionExecuted);
    }

    public override void OnActionExecuting(ActionExecutingContext actionExecuted)
    {
        if (IsMethodGet(actionExecuted)) return;

        unitOfWork.Begin();

        base.OnActionExecuting(actionExecuted);
    }
        
    private static bool Success(ActionExecutedContext actionExecuted) =>
        actionExecuted.Exception is null && actionExecuted.ModelState.IsValid;
    
    private static bool IsMethodGet(FilterContext context) => context.HttpContext.Request.Method == MethodGet;
}