using M4Movie.Api.Business.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace M4Movie.Api.Business
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(string userName, string signInKey, 
            string tokenIssuer, string tokenAudience)
        {
            var dataClaim = new[] { new Claim(ClaimTypes.Name, userName) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));
            var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: tokenIssuer,
                audience: tokenAudience,
                expires: DateTime.Now.AddMinutes(1),
                claims: dataClaim,
                signingCredentials: signInCredential
                );
            var strToken = new JwtSecurityTokenHandler().WriteToken(token);
            return strToken;
        }
    }
}
