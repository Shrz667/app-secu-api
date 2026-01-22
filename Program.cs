  using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using login.Data;
using login.Models;

var builder = WebApplication.CreateBuilder(args);

// LECTURE DE LA CLÉ JWT DEPUIS L’ENVIRONNEMENT
string jwtSecret = Environment.GetEnvironmentVariable("super cle ");

if (string.IsNullOrEmpty(jwtSecret))
{
    throw new Exception("cle JWT manquante");
}


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=logins.db"));


//ca c est pour l'authentification jwt, tokens pour acceder a lout put de lapi
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //valider la cle 
            ValidateIssuer = false,
            ValidateAudience = false,
            //duree de validite du token
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(jwtSecret)
            )
        };
    });

var app = builder.Build();





//====================================================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Logins.Any())
    {
        //hashage de tout les login actuel

        var hasher = new PasswordHasher<login>();
        db.Logins.AddRange(
            new login { numero = "user1", password = hasher.HashPassword(null, "1234") },
            new login { numero = "admin", password = hasher.HashPassword(null, "admin") },
            new login { numero = "+21321667451", password = hasher.HashPassword(null, "3703") },
              new login { numero = "+21321919808", password = hasher.HashPassword(null, "8384") },
        new login{ numero = "+21329681743", password = hasher.HashPassword(null, "1634") },
            new login { numero = "+21337327744", password = hasher.HashPassword(null, "3898") },
            new login { numero = "+21331818972", password = hasher.HashPassword(null, "1503") },
    new login { numero = "+21338863566", password = hasher.HashPassword(null, "6708") },
            new login { numero = "+21321381337", password = hasher.HashPassword(null, "0378") },
            new login { numero = "+21331942018", password = hasher.HashPassword(null, "4338") },
            new login { numero = "+21321309248", password = hasher.HashPassword(null, "7987") },
              new login { numero = "+21334235794", password = hasher.HashPassword(null, "7644") },
        );
        db.SaveChanges();
    }
}



//==========================================================
// hado la bdd en local bl sqlite zaema


app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();


app.Run();












