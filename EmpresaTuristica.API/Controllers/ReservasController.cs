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
    [Route("api/reservas")]
    public class ReservasController: ControllerBase
    {
        private readonly DataContext _context;

        public ReservasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Reservas.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var reserva = await _context.Reservas.FirstOrDefaultAsync(x => x.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Reserva reserva)
        {
            _context.Add(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Reserva reserva)
        {
            _context.Update(reserva);
            await _context.SaveChangesAsync();
            return Ok(reserva);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Reservas.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
