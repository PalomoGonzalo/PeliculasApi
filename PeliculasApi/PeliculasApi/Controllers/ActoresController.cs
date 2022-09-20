using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasApi.Dtos;
using PeliculasApi.Entidades;

namespace PeliculasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ObtenerListaActores")]
        public async Task<ActionResult<List<ActorDTO>>> ObtenerListaActores()
        {
            var entidades = await _context.Actores.ToListAsync();
            var dto = _mapper.Map<List<ActorDTO>>(entidades);
            return Ok(dto);
        }

        [HttpGet("ObtenerActorPorId/{id}")]
        public async Task<ActionResult<ActorDTO>> ObtenerActorPorId(int id)
        {
            var entidad = await _context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<ActorDTO>(entidad);
            return Ok(dto);
        }

        [HttpPost("CrearActor")]
        public async Task<ActionResult> CrearActor([FromBody] ActorCreacionDTO data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            var entidad = _mapper.Map<Actor>(data);
            _context.Actores.Add(entidad);

            await _context.SaveChangesAsync();
            var actorDTO = _mapper.Map<ActorCreacionDTO>(entidad);

            return Ok(actorDTO);
        }

    }
}
