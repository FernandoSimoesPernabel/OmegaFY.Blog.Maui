namespace OmegaFY.Blog.Maui.App.Models.APIs.Requests;

public sealed record class LoginRequest
{
    public string Email { get; }

    public string Password { get; }

    public bool RememberMe { get; }

    public LoginRequest(string email, string password, bool rememberMe)
    {
        Email = email;
        Password = password;
        RememberMe = rememberMe;
    }
}