using AlumnosMicorservicio.Modelo;
using AlumnosMicorservicio.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AlumnosMicorservicio.Aplicacion
{
    public class ConsultaAlumno
    {
        public class ListaAlumnos : IRequest<List<AlumnoDto>>
        {

        }

        public class ManejadorConsultar : IRequestHandler<ListaAlumnos, List<AlumnoDto>>
        {
            private readonly ContextoAlumnos _context;
            private readonly IMapper _mapper;

            public ManejadorConsultar(ContextoAlumnos contexto, IMapper mapper) 
            {
                _context = contexto;
                _mapper = mapper;
            }

            public async Task<List<AlumnoDto>> Handle(ListaAlumnos request, CancellationToken cancellationToken)
            {
                var alumnos = await _context.AlumnoInscrito.ToListAsync();
                var alumnosDto = _mapper.Map<List<AlumnoInscrito>, List<AlumnoDto>>(alumnos);
                return alumnosDto;
            }
        }
    }
}
