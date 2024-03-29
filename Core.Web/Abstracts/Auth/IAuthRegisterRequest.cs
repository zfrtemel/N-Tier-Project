﻿namespace Core.Web.Abstracts.Auth;

public interface IAuthRegisterRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}
