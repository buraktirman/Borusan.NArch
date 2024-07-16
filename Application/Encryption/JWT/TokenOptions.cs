namespace Application.Encryption.JWT;

public class TokenOptions
{
    public int Expiration { get; set; }
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
}
