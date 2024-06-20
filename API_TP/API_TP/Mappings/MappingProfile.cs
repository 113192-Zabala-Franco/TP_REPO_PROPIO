using API_TP.DTOS;
using AutoMapper;
using API_TP.Models;

namespace API_TP.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
        CreateMap<Alumnos, AlumnosDto>();
        CreateMap<AlumnosXCursos, AlumnosXCursosDto>();
        CreateMap<Carreras, CarrerasDto>();
        CreateMap<Cursos, CursosDto>();
        CreateMap<Docentes, DocentesDto>();
        CreateMap<DocentesXCursos, DocentesXCursosDto>();
        CreateMap<Roles, RolesDto>();
        CreateMap<Usuarios, UsuariosDto>();
        }
    }
}
