using APIHealthGo.Contracts.Service;
using APIHealthGo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Depencendcy
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddSingleton<IConnection, Connection>();
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();

builder.Services.AddScoped<ILembreteService, LembreteService>();
builder.Services.AddSingleton<IConnection, Connection>();
builder.Services.AddTransient<ILembreteRepository, LembreteRepository>();

builder.Services.AddScoped<IGerenciaService, GerenciaService>();
builder.Services.AddSingleton<IConnection, Connection>();
builder.Services.AddTransient<IGerenciaRepository, GerenciaRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
