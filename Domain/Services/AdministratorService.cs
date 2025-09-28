using System.Data.Common;
using Minimal_api.Domain.DTOs;
using Minimal_api.Domain.Entities;
using Minimal_api.Domain.Interfaces;
using Minimal_api.Infrastructure.Db.MinimalApiDbContext;

namespace Minimal_api.Domain.Services;

public class AdministratorService : IAdministratorService
{
  private readonly MinimalApiDbContext _context;
  public AdministratorService(MinimalApiDbContext context)
  {
    _context = context;
  }
  public Administrator? Login(LoginDTO loginDTO)
  {
    var admin = _context.Administrators.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
    return admin;

  }
}