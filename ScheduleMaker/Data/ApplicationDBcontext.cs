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

}