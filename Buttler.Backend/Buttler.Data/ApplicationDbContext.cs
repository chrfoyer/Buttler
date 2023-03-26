using Buttler.Domain.Model;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Buttler.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Report> Reports { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Trashcan> TrashCans { get; set; }

    public  String connection =
        "server=paneldatabase.humbleservers.com;port=3306;database=s18254_Buttler;user=u18254_wOMY0OPp2d;password=+P8.4rceKVvQ^J6JOL5w3Sr0;";
    
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    
        => optionsBuilder.UseMySql( connection,ServerVersion.AutoDetect(connection));

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>().HasKey(report => report.ReportId);
        modelBuilder.Entity<User>().HasKey(user => user.UserID);
        modelBuilder.Entity<Trashcan>().HasKey(trashcan => trashcan.TrashCanID);
    }
}