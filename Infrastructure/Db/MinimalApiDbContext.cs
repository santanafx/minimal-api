using Microsoft.EntityFrameworkCore;
using Minimal_api.Domain.Entities;

namespace Minimal_api.Infrastructure.Db.MinimalApiDbContext;

public class MinimalApiDbContext : DbContext
{
  private readonly IConfiguration _configurationAppSettings;
  public MinimalApiDbContext(IConfiguration configurationAppSettings)
  {
    _configurationAppSettings = configurationAppSettings;
  }
  public DbSet<Administrator> Administrators { get; set; } = default!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Administrator>().HasData(
      new Administrator
      {
        Id = 1,
        Email = "administrador@teste.com",
        Senha = "123456",
        Perfil = "Adm"
      }
    );
  }
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