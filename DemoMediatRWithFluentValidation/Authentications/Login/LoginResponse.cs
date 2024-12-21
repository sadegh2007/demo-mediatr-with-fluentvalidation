namespace DemoMediatRWithFluentValidation.Authentications.Login;

public class LoginResponse
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}