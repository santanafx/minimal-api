using Minimal_api.Domain.Entities.Administrator;
using Microsoft.EntityFrameworkCore;

namespace Minimal_api.Infrastructure.Db.MinimalApiDbContext;

public class MinimalApiDbContext : DbContext
{
  private readonly IConfiguration _configurationAppSettings;
  public MinimalApiDbContext(IConfiguration configurationAppSettings)
  {
    _configurationAppSettings = configurationAppSettings;
  }
  public DbSet<Administrator> Administrators { get; set; } = default!;
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var stringConexao = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
      if (!string.IsNullOrEmpty(stringConexao))
      {
        optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
      }
    }
  }
}