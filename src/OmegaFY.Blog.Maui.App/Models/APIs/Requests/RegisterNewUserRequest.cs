namespace OmegaFY.Blog.Maui.App.Models.APIs.Requests;

public sealed record class RegisterNewUserRequest
{
    public string Email { get; }

    public string DisplayName { get; }

    public string Password { get; }

    public RegisterNewUserRequest(string email, string displayName, string password)
    {
        Email = email;
        DisplayName = displayName;
        Password = password;
    }
}