using AlumnosMicorservicio.Modelo;
using AlumnosMicorservicio.Persistencia;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlumnosMicorservicio.Aplicacion
{
    public class NuevoAlumno
    {
        public class EjecutarAlumno : IRequest
        {
            public string NombreAlumno { get; set; }

            public string ApellidoPaterno { get; set; }

            public string ApellidoMaterno { get; set; }

            public DateTime? FechaInscripcion { get; set; }
        }

        public class EjecutarValidacon : AbstractValidator<EjecutarAlumno>
        {
            public EjecutarValidacon()
            {
                RuleFor(p => p.NombreAlumno).NotEmpty(); //No Acepta Valores Nulos
                RuleFor(p => p.ApellidoPaterno).NotEmpty();
                RuleFor(p => p.ApellidoMaterno).NotEmpty();
            }
        }

        public class ManejadorInsertar : IRequestHandler<EjecutarAlumno>
        {
            public readonly ContextoAlumnos _contexto;

            public ManejadorInsertar(ContextoAlumnos contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(EjecutarAlumno request, CancellationToken cancellationToken)
            {
                var alumnoInscrito = new AlumnoInscrito
                {
                    NombreAlumno = request.NombreAlumno,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    FechaInscripcion = request.FechaInscripcion,
                    AlumnoInscritoGuid = Convert.ToString(Guid.NewGuid())
                };

                _contexto.AlumnoInscrito.Add(alumnoInscrito);

                // Insertamos el Valor
                var respuesta = await _contexto.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value; // Numero de Filas Afectadas
                }
                throw new Exception("No se pudo Insertar el Alumno");
            }
        }
    }
}
