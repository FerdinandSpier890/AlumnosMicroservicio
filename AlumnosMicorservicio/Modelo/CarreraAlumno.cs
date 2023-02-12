using System;

namespace AlumnosMicorservicio.Modelo
{
    public class CarreraAlumno
    {
        public int CarreraAlumnoId { get; set; }

        public string NombreCarrera { get; set; }

        public string ControlCarrera { get; set; }

        public AlumnoInscrito AlumnoInscrito { get; set; }

        public string CarreraAlumnoGuid { get; set; }
    }
}
