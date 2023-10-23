using EmpresaTuristica.API.Data;
using EmpresaTuristica.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaTuristica.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("api/recorridos")]
    public class RecorridosController: ControllerBase
    {
        private readonly DataContext _context;

        public RecorridosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Recorridos.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var recorrido = await _context.Recorridos.FirstOrDefaultAsync(x => x.Id == id);

            if (recorrido == null)
            {
                return NotFound();
            }

            return Ok(recorrido);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Recorrido recorrido)
        {
            _context.Add(recorrido);
            await _context.SaveChangesAsync();
            return Ok(recorrido);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Recorrido recorrido)
        {
            _context.Update(recorrido);
            await _context.SaveChangesAsync();
            return Ok(recorrido);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Ciudades.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
