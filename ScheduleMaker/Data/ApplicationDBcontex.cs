using Microsoft.EntityFrameworkCore;
using ScheduleMaker.Models;

namespace ScheduleMaker.Data;

public class ApplicationDBcontex : DbContext
{
    public ApplicationDBcontex(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Event> Events { get; set; }

}