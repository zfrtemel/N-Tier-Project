namespace Core.Web.Abstracts.Auth;

public interface IAuthLoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
