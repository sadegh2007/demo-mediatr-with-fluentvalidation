using DemoMediatRWithFluentValidation.Authentications.Login.Http;

namespace DemoMediatRWithFluentValidation;

public static class Routes
{
    public static void MapRoutes(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api")
            .WithGroupName("v1");

        api.MapLoginRoutes();
    }
}