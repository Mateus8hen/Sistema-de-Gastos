using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gastos.API.DTOs.Transacao;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class TransacaoController (ITransacaoService service): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoResponseDto>>> GetAll()
            {
                var transacoes = await service.GetAllTransacaoAsync();
                return Ok(transacoes.Select(MapToResponseDTO));
            }
        
        
        [HttpGet("{id}")]
            public async Task<ActionResult<TransacaoResponseDto>> GetById(int id)
            {
                var transacao = await service.GetTransacaoByIdAsync(id);
                if (transacao == null)
                {
                    return NotFound();
                }
                return Ok(MapToResponseDTO(transacao));
            }

        [HttpPost]
        public async Task<ActionResult<TransacaoResponseDto>> Create(Transacao transacao)
            {
                var createdTransacao = await service.CreateTransacaoAsync(transacao);
                return CreatedAtAction(nameof(GetById), new { id = createdTransacao.Id }, MapToResponseDTO(createdTransacao));
            }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<TransacaoResponseDto>> Update(int id, Transacao transacao)
            {
                var updatedTransacao = await service.UpdateTransacaoAsync(id, transacao);
                if (updatedTransacao == null)
                {
                    return NotFound();
                }
                return Ok(MapToResponseDTO(updatedTransacao));
            }
        

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
            {
                var deleted = await service.DeleteTransacaoAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return Ok(deleted);
            }

    public static TransacaoResponseDto MapToResponseDTO(Transacao transacao)
    {
        return new TransacaoResponseDto
        {
            Id = transacao.Id,
            Valor = transacao.Valor,
            Vencimento = transacao.Vencimento,
            CategoriaId = transacao.CategoriaID,
            CategoriaNome = transacao.Categoria?.Nome
        };
    }
    }   
}