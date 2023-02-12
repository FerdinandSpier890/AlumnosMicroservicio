using System.Collections.Generic;
using System;

namespace AlumnosMicorservicio.Modelo
{
    public class AlumnoInscrito
    {
        public int AlumnoInscritoId { get; set; }

        public string NombreAlumno { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime? FechaInscripcion { get; set; }

        public ICollection<CarreraAlumno> CarrerasAlumnos { get; set; }

        //Seguimiento de Registro para el Microservicio
        public string AlumnoInscritoGuid { get; set; }
    }
}
