using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FitnessWorkoutTrackerApi.Service.BearerToken;

public class BearerTokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    : IBearerTokenService
{
    public void  GenerateBearerToken(string email, string username)
    {
        
        //Generate key as byte
        var securityKey = Encoding.UTF8.GetBytes(configuration["BearerToken:SecurityKey"]);
        
        // Generate credentials
        var credentials = new SigningCredentials(
            key: new SymmetricSecurityKey(securityKey),
            algorithm: SecurityAlgorithms.HmacSha256
        );
        
        //Generate claims
        var claims = new List<Claim>()
        {
            new Claim("username", username),
            new Claim("email", email),
        };
        
        //Generate token
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddMinutes(15)
        );
        
        //Write token as string
        var bearerToken = new JwtSecurityTokenHandler().WriteToken(token);

        httpContextAccessor.HttpContext?.Response.Cookies.Append("{your_token_name}", bearerToken, new CookieOptions
        {
            Expires = DateTime.Now.AddMinutes(15),
            HttpOnly = true,
            Secure = true,
            IsEssential = true,
            SameSite = SameSiteMode.None
        });





    }
}