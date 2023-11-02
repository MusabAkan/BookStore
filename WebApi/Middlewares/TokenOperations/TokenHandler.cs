using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Entities;
using WebApi.Middlewares.TokenOperations.Models;

namespace WebApi.Middlewares.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get;}
        public string RefreshToken { get; set; }

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            tokenModel.Expiration = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );
            JwtSecurityTokenHandler tokenHandler = new ();
            //token yaratıyor.
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();
            return tokenModel;
        }

        string CreateRefreshToken() => Guid.NewGuid().ToString();

    }
}
