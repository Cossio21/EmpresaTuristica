using EmpresaTuristica.API.Data;
using EmpresaTuristica.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpresaTuristica.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController: ControllerBase
    {
        private readonly DataContext _context;

        public CiudadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Ciudades.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var ciudad = await _context.Ciudades.FirstOrDefaultAsync(x => x.Id == id);

            if (ciudad == null)
            {
                return NotFound();
            }

            return Ok(ciudad);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Ciudad ciudad)
        {
            _context.Add(ciudad);
            await _context.SaveChangesAsync();
            return Ok(ciudad);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Ciudad ciudad)
        {
            _context.Update(ciudad);
            await _context.SaveChangesAsync();
            return Ok(ciudad);
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
