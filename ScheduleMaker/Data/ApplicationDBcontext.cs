using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleMaker.Models;

namespace ScheduleMaker.Data;

public class ApplicationDBcontext : IdentityDbContext<User>
{
    public ApplicationDBcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }

}