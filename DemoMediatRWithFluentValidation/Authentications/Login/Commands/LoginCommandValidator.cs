using FluentValidation;

namespace DemoMediatRWithFluentValidation.Authentications.Login.Commands;

public class LoginCommandValidator: AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().NotNull();
    }
}