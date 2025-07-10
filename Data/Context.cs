using Microsoft.EntityFrameworkCore;

namespace Person_Api.Data;

public class Context : DbContext
{
    private readonly string _configurationString;
    public Context(IConfiguration configuration)
    {
        _configurationString = configuration.GetConnectionString("Default");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql( _configurationString, ServerVersion.AutoDetect( _configurationString));
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Company> Companies { get; set; }
}