using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gastos.API.Data;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Repositories.Interfaces;

namespace Sistema_de_Gastos.API.Repositories
{
    public class Transacaorepository (AppDbContext context) : ITransacaoRepository
    {
       private readonly AppDbContext _context = context;

        public async Task<Transacao> CreateTransacaoAsync(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }

        public async Task<IList<Transacao>> GetAllTransacaoAsync()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<Transacao?> GetTransacaoByIdAsync(int id)
        {
            return await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id);
        }

          public async Task<Transacao?> GetTransacaoByNameAsync(string name)
        {
            return await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Nome == name);
        }

        public async Task<Transacao> UpdateTransacaoAsync(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }
         public async Task<bool> DeleteAsync(int id)
        {
            var transacao = await _context.Transacoes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (transacao == null)
                return false;

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}