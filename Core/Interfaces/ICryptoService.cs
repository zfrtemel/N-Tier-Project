namespace Core.Interfaces;
public interface ICryptoService
{
    public string Hash(string str);
    public bool Verify(string raw, string hash);
}
