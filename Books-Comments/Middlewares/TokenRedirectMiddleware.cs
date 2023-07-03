namespace Books_Comments.Middlewares;

public class TokenRedirectMiddleware
{
    private readonly RequestDelegate _next;
    public TokenRedirectMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Cookies.TryGetValue("Acces-Token", out var accessToken))
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                string bearerToken = String.Format("Bearer {0}", accessToken);
                httpContext.Request.Headers.Add("Authorization", bearerToken);
            }
        }
        return _next(httpContext);
    }
}