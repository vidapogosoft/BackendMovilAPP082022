using System;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Backend.App.Interface;

namespace Backend.App.Service
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {

        private readonly string _key;

        public JwtAuthenticationService(string key)
        {
            _key = key;
        }

        public string Authenticate(string username, string password)
        {
            //debe ir el proceso de verifcacion de credenciales de mis aplicativo
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)
                || username != "demo" || password != "123456")
            {
                return null;
            }

            //Si la authentication is true
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    
                    new Claim[]
                    {
                      new Claim(ClaimTypes.Name, username),
                      new Claim(ClaimTypes.Role, "user"),
                      new Claim(ClaimTypes.Country, "EC")
                    }
                    
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                TokenType = "JWT",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
