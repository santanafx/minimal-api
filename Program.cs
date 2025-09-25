

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (Minimal_api.Domain.DTOs.LoginDTO loginDTO) =>
{
  if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
  {
    return Results.Ok("Login foi realizado com sucesso!");
  }
  else
  {
    return Results.Unauthorized();
  }
});

app.Run();