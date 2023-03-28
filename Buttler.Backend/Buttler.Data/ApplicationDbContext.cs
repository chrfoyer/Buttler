using Buttler.Domain.Model;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Buttler.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Report> Reports { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Trashcan> TrashCans { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=buttler1.c0zpqoi4e1d8.eu-north-1.rds.amazonaws.com;Database=buttler_db;Username=postgres;Password=buttlerpass");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>().HasKey(report => report.ReportId);
        modelBuilder.Entity<User>().HasKey(user => user.UserID);
        modelBuilder.Entity<Trashcan>().HasKey(trashcan => trashcan.TrashCanID);
    }
}