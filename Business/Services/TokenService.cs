using Business.Interfaces;
using Core.Configs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class TokenService : ITokenService
{
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        // bu bilgiler appsettings.json dosyasından alınabilir
        // yada deploymentda güvenlik için aws içerisindeki envler içine alınabilir
        var tokenOptions = new JwtSecurityToken(
            issuer: "developer",
            audience: "developer",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Secret_Key!.41")), SecurityAlgorithms.HmacSha256Signature
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}

