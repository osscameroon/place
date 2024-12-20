using Asp.Versioning.Builder;
using Core.Identity;
using Identity.Authenticate.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using ApiVersion = Asp.Versioning.ApiVersion;

namespace Identity;

public static class AuthenticateExtensions
{
    internal static WebApplication WithAuthenticationEndpoints(this WebApplication app)
    {
        string? apiTitle = app.Configuration.GetSection("ApiVersioning:Title").Get<string>();

        ApiVersionSet apiVersionSet = app.NewApiVersionSet($"{apiTitle}")
            .HasApiVersion(new ApiVersion(1.0))
            .ReportApiVersions()
            .Build();

        RouteGroupBuilder groupBuilder = app.MapGroup("api/v{apiVersion:apiVersion}")
            .WithApiVersionSet(apiVersionSet);

        groupBuilder.MapAuthenticationEndpoints<ApplicationUser>().WithTags("Identity");

        return app;
    }
}
