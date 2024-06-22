using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElectronicObserverDataAPI.Handlers;

public class CheckForUserAgentAttribute : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        string? userAgent = context.HttpContext.Request.Headers.UserAgent;

        if (string.IsNullOrEmpty(userAgent) || !userAgent.StartsWith("ElectronicObserverEN"))
        {
            context.Result = new ForbidResult();
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {

    }
}