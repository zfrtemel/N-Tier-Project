namespace Core.Configs;

public class JwtConfig
{
    public string? Audience { get; set; } = "user";
    public string? Issuer { get; set; } = "admin";
    public string SecretKey { get; set; } = "";
    public int ExpireDay { get; set; } = 30;
    public int RefreshTokenExpireDay { get; set; } = 7;
}
