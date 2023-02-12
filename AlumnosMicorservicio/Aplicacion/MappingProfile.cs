using AlumnosMicorservicio.Modelo;
using AutoMapper;

namespace AlumnosMicorservicio.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlumnoInscrito, AlumnoDto>();
        }
    }
}
