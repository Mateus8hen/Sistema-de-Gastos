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
        return Ok(categorias.Select(MapToResponseDTO));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetById(int id)
    {
        var categoria = await service.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(MapToResponseDTO(categoria));
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetByName(string name)
    {
        var categoria = await service.GetCategoriaByNameAsync(name);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(MapToResponseDTO(categoria));
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaResponseDto>> Create(CategoriaCreateDto dto)
    {
        try
        {
            var categoria = await service.CreateCategoriaAsync(new Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            });

            var response = MapToResponseDTO(categoria);
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

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoriaResponseDto>> Update(int id, CategoriaCreateDto dto)
    {
        var categoria = await service.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }

        categoria.Nome = dto.Nome;
        categoria.Descricao = dto.Descricao;

        var atualizarCategoria = await service.UpdateCategoriaAsync(categoria);
        return Ok(MapToResponseDTO(atualizarCategoria));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await service.GetCategoriaByIdAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }

        var Apagarcategoria = await service.DeleteCategoriaAsync(id);
        if (!Apagarcategoria)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
            {
                Title = "Erro ao deletar categoria",
                Detail = "Ocorreu um erro ao tentar deletar a categoria.",
                Status = StatusCodes.Status500InternalServerError
            });
        }

        return NoContent();
    }

    private static CategoriaResponseDto MapToResponseDTO(Categoria categoria)
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