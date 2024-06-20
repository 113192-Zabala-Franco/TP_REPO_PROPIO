using API_TP.DTOS;
using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Query.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces
{
    public interface IAlumnoRepository
    {
        Task<List<Alumnos>> GetAllAlumnos();
        Task<Alumnos> GetAlumnosById(int id);
        Task<Alumnos> PostAlumno([FromBody]NuevoAlumnoQuery query);
        Task<Alumnos> PutAlumno([FromBody] NuevoAlumnoQuery query);
        Task<bool> DeleteAlumno(int id);
    }
}
