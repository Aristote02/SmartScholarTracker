using System.Net;

namespace StudentProgress.Presentation.Middlewares;

public class CustomAuthenticationMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public CustomAuthenticationMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["token"];
        //Console.WriteLine(token);
        if (!String.IsNullOrEmpty(token))
            context.Request.Headers.Add("Authorization", $"Bearer {token}");

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            context.Response.Redirect("/User/Login");
        await _requestDelegate(context);
    }
}
