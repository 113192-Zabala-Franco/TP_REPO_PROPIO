using API_TP.DTOS;
using API_TP.Query.Alumnos;
using API_TP.Query.Docentes;
using API_TP.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces.IDocentes
{
    public interface IDocenteServices
    {
        Task<ApiResponse<List<DocentesDto>>> GetAllDocentes();
        Task<ApiResponse<DocentesDto>> GetDocenteById(int id);
        Task<ApiResponse<DocentesDto>> PostDocente([FromBody] NuevoDocenteQuery query);
        Task<ApiResponse<DocentesDto>> PutDocente([FromBody] NuevoDocenteQuery query);
        Task<ApiResponse<bool>> DeleteDocenteById(int id);
    }
}
