using Microsoft.EntityFrameworkCore;
using Sistema_de_Gastos.API.Models;

namespace Sistema_de_Gastos.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; } = null!;
}