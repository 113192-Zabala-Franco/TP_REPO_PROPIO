using API_TP.DTOS;
using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces
{
    public interface IAlumnoServices
    {
        Task<ApiResponse<List<AlumnosDto>>> GetAllAlumnos();
        Task<ApiResponse<AlumnosDto>> GetAlumnoById(int id);
        Task<ApiResponse<AlumnosDto>> PostAlumno([FromBody] NuevoAlumnoQuery query);
        Task<ApiResponse<AlumnosDto>> PutAlumno([FromBody] NuevoAlumnoQuery query);
        Task<ApiResponse<bool>> DeleteAlumnoById(int id);
    }
}
