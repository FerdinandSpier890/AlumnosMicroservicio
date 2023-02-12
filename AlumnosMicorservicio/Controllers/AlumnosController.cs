using AlumnosMicorservicio.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlumnosMicorservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoAlumno.EjecutarAlumno data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDto>>> GetAutores()
        {
            return await _mediator.Send(new ConsultaAlumno.ListaAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDto>> GetAutorLibro(string id)
        {
            return await _mediator.Send(new AlumnoFiltro.AlumnoUnico { AlumnoInscritoGuid = id });
        }
    }
}
