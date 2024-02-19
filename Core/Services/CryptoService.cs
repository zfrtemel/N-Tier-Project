using Core.Interfaces;

namespace Core.Services;
public class CryptoService : ICryptoService
{
    public string Hash(string str)
    {
        return BCrypt.Net.BCrypt.HashPassword(str);
    }

    public bool Verify(string raw, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(raw, hash);
    }
}
