using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi.Dtos;
using PeliculasApi.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PeliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenerosController(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet("ObtenerListaGenero")]
        public async Task<ActionResult<List<GeneroDTO>>> ObtenerListaGenero()
        {
            var entidades = await _context.Generos.ToListAsync();
            var dtos = _mapper.Map<List<GeneroDTO>>(entidades);
            return Ok(dtos);
        }

        [HttpGet("ObtenerGeneroPorId/{id}")]
        public async Task<ActionResult<GeneroDTO>> ObtenerGeneroPorId(int id)
        {
            var entidad = await _context.Generos.FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null)
            {
                return NotFound();
            }


            var dtos = _mapper.Map<GeneroDTO>(entidad);
            return Ok(dtos);
        }

        [HttpPost("CrearGenero")]
        public async Task<ActionResult> CrearGenero([FromBody] GeneroCreacionDTO data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            var entidad = _mapper.Map<Genero>(data);
            _context.Generos.Add(entidad);

            await _context.SaveChangesAsync();
            var generoDTO = _mapper.Map<GeneroDTO>(entidad);

            return Ok(generoDTO);

        }

        [HttpPut("ModificarGenero/{id}")]
        public async Task<ActionResult> ModificarGenero(int id,[FromBody] GeneroCreacionDTO data)
        {
            var entidad = _mapper.Map<Genero>(data);
            entidad.Id = id;

            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        
        [HttpDelete("EliminarGenero/{id}")]

        public async Task<ActionResult> EliminarGenero(int id)
        {
            var existe = await _context.Generos.AnyAsync(x=>x.Id==id);
            if (!existe)
            {
                return NotFound();
            }
            _context.Remove(new Genero() { Id = id });
            await _context.SaveChangesAsync();

            return NoContent();

        }




    }
}
