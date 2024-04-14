using Microsoft.EntityFrameworkCore;
using ScheduleMaker.Models;

namespace ScheduleMaker.Data;

public class ApplicationDBcontext : DbContext
{
    public ApplicationDBcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Event> Events { get; set; }

}