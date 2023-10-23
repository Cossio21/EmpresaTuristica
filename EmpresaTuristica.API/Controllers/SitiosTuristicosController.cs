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
    [Route("api/sitiosturisticos")]
    public class SitiosTuristicosController: ControllerBase
    {
        private readonly DataContext _context;

        public SitiosTuristicosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.SitiosTuristicos.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var sitioturistico = await _context.SitiosTuristicos.FirstOrDefaultAsync(x => x.Id == id);

            if (sitioturistico == null)
            {
                return NotFound();
            }

            return Ok(sitioturistico);

        }


        [HttpPost]
        public async Task<ActionResult> Post(SitioTuristico sitioTuristico)
        {
            _context.Add(sitioTuristico);
            await _context.SaveChangesAsync();
            return Ok(sitioTuristico);
        }

        [HttpPut]
        public async Task<ActionResult> Put(SitioTuristico sitioTuristico)
        {
            _context.Update(sitioTuristico);
            await _context.SaveChangesAsync();
            return Ok(sitioTuristico);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.SitiosTuristicos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}
