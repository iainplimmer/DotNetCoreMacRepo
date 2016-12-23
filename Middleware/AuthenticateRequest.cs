using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AuthenticateRequest
{
    private readonly RequestDelegate _next;

    public AuthenticateRequest(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)  
    {
        //  Let's setup some variables to test the path and see if the authentication
        //  key has been provided to the request.
        var path = context.Request.Path.ToString();
        var headerKeys = context.Request.Headers.Keys;
        var hasAuthKey = headerKeys.Contains("auth-key");

        //  Only check this key is present when using the API, normal 'MVC' routes are excluded
        if (path != null && path.Length > 4 
            && !hasAuthKey 
            && path.Substring(0,5).ToLower() == "/api/")
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("You must supply an authentication key.");
            return;
        }

        await _next.Invoke(context);
    }
}