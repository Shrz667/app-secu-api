using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using login.Models;
namespace prototype_app_secu.Data2
{
    // public class loginapi
    // {
        
    // }
public class AppDbContext : DbContext
{
    public DbSet<login> logins { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
}