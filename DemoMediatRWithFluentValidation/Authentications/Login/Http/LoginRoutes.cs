using DemoMediatRWithFluentValidation.Authentications.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatRWithFluentValidation.Authentications.Login.Http;

public static class LoginRoutes
{
    public static IEndpointRouteBuilder MapLoginRoutes(this IEndpointRouteBuilder endpoints)
    {
        var api = endpoints.MapGroup("auth/login");

        api.MapPost("", Login).AllowAnonymous();
        
        return api;
    }
    
    private static async Task<IResult> Login([FromBody] LoginCommand command, IMediator mediator)
        => Results.Ok(await mediator.Send(command));
}