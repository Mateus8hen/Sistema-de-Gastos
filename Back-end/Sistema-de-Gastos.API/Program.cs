using Microsoft.EntityFrameworkCore;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Interfaces;
using Sistema_de_Gastos.API.Repositories;
using Sistema_de_Gastos.API.Services;
using Sistema_de_Gastos.API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Entity Framework + MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    ));

// Controllers
builder.Services.AddControllers();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
