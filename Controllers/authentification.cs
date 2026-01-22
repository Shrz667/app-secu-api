using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using login.Data;
using login.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/protected")]// hadi pour proteger l api d auth 
public class ProtectedController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _config;
    private readonly PasswordHasher<login> _hasher;

    public ProtectedController(AppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
        _hasher = new PasswordHasher<login>();
    }
    //hoster la partie login du site
    [HttpPost("login")]
    //hna y eura les request des user pour le login
    public IActionResult Login([FromBody] LoginRequest request)
    {
        //  verif de  l'utilisateur
        var user = _db.Logins.FirstOrDefault(x => x.numero == request.Numero);
        if (user == null)
            return Unauthorized("l utilisteur ne figure pas dans la base de donnee");

        //  verif le mot de passe
        var result = _hasher.VerifyHashedPassword(
            user,
            user.password,
            request.Password
        );

        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("Mot de passe incorrect");

        //  generer le JWT
        var token = GenerateJwt(user.numero);


        // renvoyer le token
        return Ok(new { token });
    }

    private string GenerateJwt(string numero)
    {
        var key = Encoding.UTF8.GetBytes(
            Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        );

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, numero),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var token = new JwtSecurityToken(
            claims: claims,
            // le token est valable 1 heure par defaut 
            //on va dire que le user a le droit d etre connecter 2 heures, sema si yas envoie d une cle avec le meme login elle n est valable que 2h
            //ca va etre flexible selon le type de user 
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
