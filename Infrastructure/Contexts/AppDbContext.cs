using Microsoft.EntityFrameworkCore;
using SimplifiedSlotMachineV1.Domain.Models;

namespace SimplifiedSlotMachineV1.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}