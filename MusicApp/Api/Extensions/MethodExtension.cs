using Microsoft.AspNetCore.Mvc.Filters;

namespace MusicApp.Api.Extensions;

public static class MethodExtension
{
    private const string MethodGet = "GET";
    
    public static bool IsMethodGet(this FilterContext context) => 
        context.HttpContext.Request.Method == MethodGet;
}