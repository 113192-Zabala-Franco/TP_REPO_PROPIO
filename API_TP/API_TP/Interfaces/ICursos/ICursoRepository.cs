using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Query.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces.ICursos
{
    public interface ICursoRepository
    {
        Task<List<Cursos>> GetAllCursos();
        Task<Cursos> GetCursoById(int id);
        Task<Cursos> PostCurso([FromBody] NuevoCursoQuery query);
        Task<Cursos> PutCurso([FromBody] NuevoCursoQuery query);
        Task<bool> DeleteCurso(int id);
    }
}
