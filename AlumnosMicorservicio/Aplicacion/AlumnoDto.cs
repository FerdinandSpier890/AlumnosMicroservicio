using AlumnosMicorservicio.Modelo;
using System.Collections.Generic;
using System;

namespace AlumnosMicorservicio.Aplicacion
{
    public class AlumnoDto
    {
        public int AlumnoInscritoId { get; set; }

        public string NombreAlumno { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public DateTime? FechaInscripcion { get; set; }

        //Seguimiento de Registro para el Microservicio
        public string AlumnoInscritoGuid { get; set; }
    }
}
