using BubberDinner.Domain.Models.MenuAggregate;

using Microsoft.EntityFrameworkCore;

namespace BubberDinner.Infrastructure.Persistent;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {

    }
    public DbSet<Menu> Menus { get; set; }
}