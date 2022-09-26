using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PeliculasApi.Controllers
{
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
<<<<<<< HEAD
        
=======
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
        }

>>>>>>> 4c0ad7531bd11abefa8e285ed8783c8cd8579d96
       
    }
}