using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Gastos.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}