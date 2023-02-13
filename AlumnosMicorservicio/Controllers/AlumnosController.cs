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

        //Se agrego el constructor para la inyeccion de dependencias
        public AlumnosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoAlumno.EjecutarAlumno data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AlumnoDto>>> GetAlumno()
        {
            return await _mediator.Send(new ConsultaAlumno.ListaAlumnos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDto>> GetAlumnoInscrito(string id)
        {
            return await _mediator.Send(new AlumnoFiltro.AlumnoUnico { AlumnoInscritoGuid = id });
        }
    }
}
