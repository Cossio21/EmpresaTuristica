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
    [Route("api/guias")]
    public class GuiasController : ControllerBase
    {
        private readonly DataContext _context;

        public GuiasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Guias.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var guia = await _context.Guias.FirstOrDefaultAsync(x => x.Id == id);

            if (guia == null)
            {
                return NotFound();
            }

            return Ok(guia);

        }

        [HttpPost]
        public async Task<ActionResult> Post(Guia guia)
        {
            _context.Add(guia);
            await _context.SaveChangesAsync();
            return Ok(guia);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Guia guia)
        {
            _context.Update(guia);
            await _context.SaveChangesAsync();
            return Ok(guia);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Guias.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
