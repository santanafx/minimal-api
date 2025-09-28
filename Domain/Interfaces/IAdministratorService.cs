using Minimal_api.Domain.DTOs;
using Minimal_api.Domain.Entities;

namespace Minimal_api.Domain.Interfaces;

public interface IAdministratorService
{
  Administrator? Login(LoginDTO loginDTO);
}