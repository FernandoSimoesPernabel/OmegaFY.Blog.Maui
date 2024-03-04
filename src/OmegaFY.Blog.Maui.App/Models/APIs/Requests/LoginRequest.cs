namespace OmegaFY.Blog.Maui.App.Models.APIs.Requests;

public sealed record class LoginRequest
{
    public string Email { get; }

    public string Password { get; }

    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}