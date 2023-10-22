using EmpresaTuristica.API.Data;
using EmpresaTuristica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaTuristica.API.Controllers
{
    [ApiController]
    [Route("api/actividades")]
    public class ActividadesController: ControllerBase
    {
        private readonly DataContext _context;

        public ActividadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Actividades.ToListAsync());

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var actividad = await _context.Actividades.FirstOrDefaultAsync(x => x.Id == id);

            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);

        }


        [HttpPost]
        public async Task<ActionResult> Post(Actividad Actividad)
        {
            _context.Add(Actividad);
            await _context.SaveChangesAsync();
            return Ok(Actividad);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Actividad actividad)
        {
            _context.Update(actividad);
            await _context.SaveChangesAsync();
            return Ok(actividad);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Actividades.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
