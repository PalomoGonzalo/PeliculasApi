using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasApi.Dtos;
using PeliculasApi.Entidades;

namespace PeliculasApi.Controllers
{
    [Route("api/[controller]")]
    public class PeliculasController : Controller
    {
        private readonly ILogger<PeliculasController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public PeliculasController(ILogger<PeliculasController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("ObtenerListaPelicula")]
        public async Task <ActionResult<List<PeliculaDTO>>> ListarPeliculas()
        {
            var entidad= await _context.Peliculas.ToListAsync();
            
            if(entidad==null)
            {
                return NotFound("No existe la pelicula");
            }

            var dto = _mapper.Map<List<PeliculaDTO>>(entidad);
            return Ok(dto);
        }


        [HttpGet("ObtenerListaPeliculaPorId/{id}")]
        public async Task <ActionResult> ListarPeliculaPorId(int id)
        {
            var entidad = await _context.Peliculas.FirstOrDefaultAsync(e => e.Id==id);
            if(entidad==null)
            {
                return NotFound("El id no existe");
            }

            return Ok(_mapper.Map<PeliculaDTO>(entidad));

        }
    }
}