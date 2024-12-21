using MediatR;

namespace DemoMediatRWithFluentValidation.Authentications.Login.Commands;

public record LoginCommand(string Email, string Password): IRequest<LoginResponse>;