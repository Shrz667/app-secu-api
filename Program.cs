  using Microsoft.AspNetCore.Authentication.JwtBearer;
 using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using login.Data;
using login.Models;

var builder = WebApplication.CreateBuilder(args);

// SERVICES
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=logins.db"));

var app = builder.Build();





//====================================================================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Logins.Any())
    {
        db.Logins.AddRange(
            new login { numero = "user1", password = "1234" },
            new login { numero = "admin", password = "admin" },
            new login { numero = "+21321667451", password = "3703" },
              new login { numero = "+21321919808", password = "8384" },
        new login{ numero = "+21329681743", password = "1634" },
            new login { numero = "+21337327744", password = "3898" },
            new login { numero = "+21331818972", password = "1503" },
    new login { numero = "+21338863566", password = "6708" },
            new login { numero = "+21321381337", password = "0378" },
            new login { numero = "+21331942018", password = "4338" },
            new login { numero = "+21321309248", password = "7987" },
              new login { numero = "+21334235794", password = "7644" },
        );
        db.SaveChanges();
    }
}
//==========================================================
// hado la bdd en local bl sqlite zaema
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();












//   var builder = WebApplication.CreateBuilder(args);
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     db.Database.EnsureCreated();
// }

//     //Add services to the container.
//   builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlite("Data Source=logins.db"));

//   var app = builder.Build();
//    Console.WriteLine("i was here");

//     //Configure the HTTP request pipeline.
//   if (!app.Environment.IsDevelopment())
//   {
//         // app.UseExceptionHandler("/Home/Error");
//         //   The default HSTS value is 30 days. You may want to change this for production scenarios, see https: aka.ms/aspnetcore-hsts.
//         // app.UseHsts();
    
//   }


//   app.UseHttpsRedirection();
//   app.UseRouting();

//   app.UseAuthorization();

//   app.MapStaticAssets();

//   app.MapControllerRoute(
//       name: "default",
//       pattern: "{controller=Home}/{action=Index}/{id?}")
//       .WithStaticAssets();


// app.Run();