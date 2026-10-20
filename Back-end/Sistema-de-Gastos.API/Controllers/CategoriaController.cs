using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gastos.API.DTOs.Categoria;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(ICategoriaService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> GetAll()
    {
        var categorias = await service.GetAllCategoriaAsync();
        return Ok(categorias.Select(MapToResponse));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetById(int id)
    {
        var categoria = await service.GetCategoriaByIdAsync(id);
        return categoria is null ? NotFound() : Ok(MapToResponse(categoria));
    }

    [HttpGet("nome/{nome}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetByName(string nome)
    {
        var categoria = await service.GetCategoriaByNameAsync(nome);
        return categoria is null ? NotFound() : Ok(MapToResponse(categoria));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaResponseDto>> Create(
        CategoriaCreateDto dto)
    {
        try
        {
            var categoria = await service.CreateCategoriaAsync(new Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            });

            var response = MapToResponse(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, response);
        }
        catch (ArgumentException exception)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Categoria inválida",
                Detail = exception.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CategoriaResponseDto>> Update(
        int id,
        CategoriaCreateDto dto)
    {
        if (await service.GetCategoriaByIdAsync(id) is null)
            return NotFound();

        try
        {
            var categoria = await service.UpdateCategoriaAsync(new Categoria
            {
                Id = id,
                Nome = dto.Nome,
                Descricao = dto.Descricao
            });

            return Ok(MapToResponse(categoria));
        }
        catch (ArgumentException exception)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Categoria inválida",
                Detail = exception.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await service.DeleteCategoriaAsync(id);
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (InvalidOperationException exception)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Categoria não pode ser excluída",
                Detail = exception.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
    }

    private static CategoriaResponseDto MapToResponse(Categoria categoria)
    {
        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nome = categoria.Nome,
            Descricao = categoria.Descricao,
            Criacao = categoria.Criacao,
            IsAtivo = categoria.IsAtivo
        };
    }
}