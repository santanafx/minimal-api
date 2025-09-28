using Minimal_api.Domain.DTOs;
using Minimal_api.Domain.Entities;

namespace Minimal_api.Domain.Interfaces;

public interface IVehicleService
{
  List<Vehicle> Todos(int page = 1, string? nome = null, string? marca = null);

  Vehicle? BuscaPorId(int id);

  void Incluir(Vehicle veiculo);
  void Atualizar(Vehicle veiculo);
  void Apagar(Vehicle veiculo);
}