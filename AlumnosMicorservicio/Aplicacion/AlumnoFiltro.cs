using AlumnosMicorservicio.Modelo;
using AlumnosMicorservicio.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlumnosMicorservicio.Aplicacion
{
    public class AlumnoFiltro
    {
        public class AlumnoUnico : IRequest<AlumnoDto> 
        { 
            public string AlumnoInscritoGuid { get; set; }
        }  

        public class ManejadorFiltro : IRequestHandler<AlumnoUnico, AlumnoDto>
        {
            private readonly ContextoAlumnos _contexto;
            private readonly IMapper _mapper;

            public ManejadorFiltro(ContextoAlumnos contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<AlumnoDto> Handle(AlumnoUnico request, CancellationToken cancellationToken)
            {
                var alumno = await _contexto.AlumnoInscrito
                    .Where(p => p.AlumnoInscritoGuid == request.AlumnoInscritoGuid).FirstOrDefaultAsync();
                if (alumno == null)
                {
                    throw new Exception("No se Encontró el Alumno");
                }
                var alumnoDto = _mapper.Map<AlumnoInscrito, AlumnoDto>(alumno);
                return alumnoDto;
            }
        }
    }
}
