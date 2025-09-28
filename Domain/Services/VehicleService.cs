using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Minimal_api.Domain.DTOs;
using Minimal_api.Domain.Entities;
using Minimal_api.Domain.Interfaces;
using Minimal_api.Infrastructure.Db.MinimalApiDbContext;

namespace Minimal_api.Domain.Services;

public class VehicleService : IVehicleService
{
  private readonly MinimalApiDbContext _context;
  public VehicleService(MinimalApiDbContext context)
  {
    _context = context;
  }

  public void Apagar(Vehicle veiculo)
  {
    _context.Vehicles.Remove(veiculo);
    _context.SaveChanges();
  }

  public void Atualizar(Vehicle veiculo)
  {
    _context.Vehicles.Update(veiculo);
    _context.SaveChanges();
  }

  public Vehicle? BuscaPorId(int id)
  {
    return _context.Vehicles.Where(v => v.Id == id).FirstOrDefault();
  }

  public void Incluir(Vehicle veiculo)
  {
    _context.Vehicles.Add(veiculo);
    _context.SaveChanges();
  }

  public List<Vehicle> Todos(int page = 1, string? nome = null, string? marca = null)
  {
    var query = _context.Vehicles.AsQueryable();
    if (!string.IsNullOrEmpty(nome))
    {
      query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
    }

    int itensPorPagina = 10;

    query = query.Skip((page - 1) * itensPorPagina).Take(itensPorPagina);

    return query.ToList();
  }
}