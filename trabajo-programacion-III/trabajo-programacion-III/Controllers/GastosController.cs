using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabajo_programacion_III.Models;
using trabajo_programacion_III.DTO;


namespace trabajo_programacion_III.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly AppDBcontext _context;
        public GastosController(AppDBcontext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<GastosDTO>>> Get()
        {
            var gastos = await _context.Gastos
                .ToListAsync();

            var gastosDTO = gastos.Select(g => new GastosDTO
            {
                id = g.Id,
                monto = g.Monto,
                descripcion = g.Descripcion,
                fecha = g.Fecha,
                nombrecomercio = g.NombreComercio

            }).ToList();

            return Ok(gastosDTO);
        }

        [HttpPost]

        public async Task<ActionResult<Gastos>> Post(Gastos gastos)
        {
            if (gastos.Fecha > DateTime.Today)
            {
                return BadRequest("La fecha no puede ser futura.");
            }
            _context.Gastos.Add(gastos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gastos}, gastos);
        }
    }
}
