using MeuPrimeiroCrud.Repository;
using MinhaPrimeiraApi.Contracts.Connection;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Infrastructure;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//Dependências
builder.Services.AddSingleton<IConnection, Connection>();

builder.Services.AddTransient<IAeroportoRepository, AeroportoRepository>();
builder.Services.AddTransient<ICidadeRepository, CidadeRepository>();
builder.Services.AddTransient<IEstadoRepository, EstadoRepository>();
builder.Services.AddTransient<INacaoRepository, NacaoRepository>();

builder.Services.AddScoped<IAeroportoService, AeroportoService>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<INacaoService, NacaoService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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