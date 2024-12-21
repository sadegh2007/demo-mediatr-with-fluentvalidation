using MediatR;

namespace DemoMediatRWithFluentValidation.Authentications.Login.Commands;

public class LoginCommandHandler: IRequestHandler<LoginCommand, LoginResponse>
{
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new LoginResponse
        {
            Email = request.Email,
            Password = request.Password
        });
    }
}