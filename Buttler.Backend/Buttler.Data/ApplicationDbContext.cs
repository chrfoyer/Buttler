using Buttler.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Buttler.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Report> Reports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../Buttler.Data/Database.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>().HasKey(report => report.ReportId);
    }
}