﻿namespace OmegaFY.Blog.Maui.App.Infra.ExternalServices.DTOs;

public class RegisterNewUserCommand
{
    public string Email { get; set; }

    public string DisplayName { get; set; }

    public string Password { internal get; set; }

    public RegisterNewUserCommand() { }

    public RegisterNewUserCommand(string email, string displayName, string password)
    {
        Email = email;
        DisplayName = displayName;
        Password = password;
    }
}