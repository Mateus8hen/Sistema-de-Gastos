using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gastos.API.Models;
using Sistema_de_Gastos.API.Services.Interface;

namespace Sistema_de_Gastos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetaFinanceiraController(IMetaFinanceiraService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaFinanceira>>> GetAll()
        {
            var metas = await service.GetAllMetaFinanceiraAsync();
            return Ok(metas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetaFinanceira>> Get(int id)
        {
            var meta = await service.GetMetaFinanceiraByIdAsync(id);
            if (meta == null)
                return NotFound();

            return Ok(meta);
        }

        [HttpPost]
        public async Task<ActionResult<MetaFinanceira>> Create([FromBody] MetaFinanceira meta)
        {
            var createdMeta = await service.CreateMetaFinanceiraAsync(meta);
            return CreatedAtAction(nameof(Get), new { id = createdMeta.Id }, createdMeta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MetaFinanceira>> Update(int id, [FromBody] MetaFinanceira meta)
        {
            var updatedMeta = await service.UpdateMetaFinanceiraAsync(id, meta);
            return Ok(updatedMeta);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await service.DeleteMetaFinanceiraAsync(id);
            return Ok(deleted);
        }
    }
}