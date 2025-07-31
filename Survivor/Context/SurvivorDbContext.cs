using Microsoft.EntityFrameworkCore;
using Survivor.Models;

namespace Survivor.Context;

    public class SurvivorDbContext : DbContext
    {
    public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
    {

    }

    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competitor>()
            .HasOne(b => b.Category)
            .WithMany(a => a.Competitors)
            .HasForeignKey(b => b.CategoryId);
        base.OnModelCreating(modelBuilder);
    }

    }




