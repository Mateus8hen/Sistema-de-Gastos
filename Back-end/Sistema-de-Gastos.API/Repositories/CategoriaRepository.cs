using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Interfaces;

namespace Sistema_de_Gastos.API.Repositories.Interfaces
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}