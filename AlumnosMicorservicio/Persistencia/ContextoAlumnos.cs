using AlumnosMicorservicio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace AlumnosMicorservicio.Persistencia
{
    public class ContextoAlumnos : DbContext
    {
        public ContextoAlumnos(DbContextOptions<ContextoAlumnos> options) : base(options) 
        {

        }

        public DbSet<AlumnoInscrito> AlumnoInscrito { get; set; }

        public DbSet<CarreraAlumno> CarreraAlumno { get; set; }
    }
}
