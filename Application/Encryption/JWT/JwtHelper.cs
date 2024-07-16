using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Encryption.JWT;

public class JwtHelper : ITokenHelper
{
    private readonly TokenOptions _tokenOptions;
    public JwtHelper(TokenOptions tokenOptions)
    {
        _tokenOptions = tokenOptions;
    }
    public string CreateToken(User user)
    {
        DateTime expirationDate = DateTime.Now.AddMinutes(15); // Konfigürasyondan gelmeli.

        //Bu key'i kullanarak encryption yapacağız
        byte[] key = Encoding.UTF8.GetBytes("ABCAJSBDI123456789ABC123456789BEQWRTWERTRQWEWQE");
        // Simetrik, Asimetrik
        SecurityKey securityKey = new SymmetricSecurityKey(key);

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: "borusanotomotiv",
            audience: "borusancustomers",
            notBefore: DateTime.Now,
            expires: expirationDate,
            signingCredentials: signingCredentials,
            claims: SetClaims(user));

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
    }

    private IEnumerable<Claim> SetClaims(User user)
    {
        List<Claim> claims = new();
        claims.Add(new Claim("Deneme", "123"));
        return claims;
    }
}
