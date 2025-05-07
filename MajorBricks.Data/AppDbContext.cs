using MajorBricks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MajorBricks.Data;

public class AppDbContext : DbContext
{
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Set> Sets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Hier kannst Du später Constraints, Indizes etc. konfigurieren
               base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Manufacturer>().HasData(
        new Manufacturer { Id = 1, Name = "Lego" }
    );
        _ = modelBuilder.Entity<Set>().HasData(
            new Set
            {
                Id = 1,
                Name = "Millennium Falcon",
                ArticleNumber = "75192",
                Year = 2018,
                PartCount = 7541,
                ManufacturerId = 1
            }
        );
    }
}
