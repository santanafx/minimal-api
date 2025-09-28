using Minimal_api.Infrastructure.Db.MinimalApiDbContext;
using Minimal_api.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Minimal_api.Domain.Interfaces;
using Minimal_api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdministratorService, AdministratorService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MinimalApiDbContext>(options =>
{
  options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
  );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministratorService administratorService) =>
{
  if (administratorService.Login(loginDTO) != null)
  {
    return Results.Ok("Login foi realizado com sucesso!");
  }
  else
  {
    return Results.Unauthorized();
  }
});

app.UseSwagger();
app.UseSwaggerUI();

app.Run();