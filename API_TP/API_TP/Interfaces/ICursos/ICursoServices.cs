using API_TP.DTOS;
using API_TP.Query.Alumnos;
using API_TP.Query.Cursos;
using API_TP.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces.ICursos
{
    public interface ICursoServices
    {
        Task<ApiResponse<List<CursosDto>>> GetAllCursos();
        Task<ApiResponse<CursosDto>> GetCursoById(int id);
        Task<ApiResponse<CursosDto>> PostCurso([FromBody] NuevoCursoQuery query);
        Task<ApiResponse<CursosDto>> PutCurso([FromBody] NuevoCursoQuery query);
        Task<ApiResponse<bool>> DeleteCursoById(int id);
    }
}
