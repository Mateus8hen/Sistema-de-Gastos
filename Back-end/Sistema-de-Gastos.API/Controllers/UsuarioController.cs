using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gastos.API.DTOs.Usuario;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(IUsuarioService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> GetAllUsuariosAsync()
        {
            var usuarios = await service.GetAllUsuarioAsync();
            return Ok(usuarios.Select(MapToResponseDTO));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetUsuarioByIdAsync(int id)
        {
            var usuario = await service.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(MapToResponseDTO(usuario));
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<UsuarioResponseDto>> GetUsuarioByNameAsync(string name)
        {
            var usuario = await service.GetUsuarioByNameAsync(name);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(MapToResponseDTO(usuario));
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDto>> CreateUsuarioAsync(UsuarioCreateDto dto)
        {
            try
            {
                var usuario = await service.CreateUsuarioAsync(new Models.Usuario
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    SenhaHash = dto.Senha
                });

                var response = MapToResponseDTO(usuario);
                return CreatedAtAction(nameof(GetUsuarioByIdAsync), new { id = usuario.Id }, response);
            }
            catch (ArgumentException exception)
            {
                return Conflict(new ProblemDetails
                {
                    Title = "Usuário inválido",
                    Detail = exception.Message,
                    Status = 409
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioResponseDto>> UpdateUsuarioAsync(int id, UsuarioCreateDto dto)
        {
            try
            {
                var usuario = await service.UpdateUsuarioAsync(new Models.Usuario
                {
                    Id = id,
                    Nome = dto.Nome,
                    Email = dto.Email,
                    SenhaHash = dto.Senha,
                    IsAtivo = dto.IsAtivo
                });

                if (usuario == null)
                {
                    return NotFound();
                }

                var response = MapToResponseDTO(usuario);
                return Ok(response);
            }
            catch (ArgumentException exception)
            {
                return Conflict(new ProblemDetails
                {
                    Title = "Usuário inválido",
                    Detail = exception.Message,
                    Status = 409
                });
            }
        }

        private UsuarioResponseDto MapToResponseDTO(Models.Usuario usuario)
        {
            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                IsAtivo = usuario.IsAtivo
            };
        }
    }
}