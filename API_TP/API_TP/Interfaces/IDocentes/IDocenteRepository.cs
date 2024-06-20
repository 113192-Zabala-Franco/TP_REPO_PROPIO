using API_TP.DTOS;
using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Query.Docentes;
using API_TP.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Interfaces.IDocentes
{
    public interface IDocenteRepository
    {
        Task<List<Docentes>> GetAllDocentes();
        Task<Docentes> GetDocenteById(int id);
        Task<Docentes> PostDocente([FromBody] NuevoDocenteQuery query);
        Task<Docentes> PutDocente([FromBody] NuevoDocenteQuery query);
        Task<bool> DeleteDocente(int id);
    }
}
