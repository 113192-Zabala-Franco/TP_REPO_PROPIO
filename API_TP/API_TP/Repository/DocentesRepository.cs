using API_TP.Data;
using API_TP.Interfaces.IDocentes;
using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Query.Docentes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TP.Repository
{
    public class DocentesRepository : IDocenteRepository
    {
        private readonly ContextTP _contexto;

        public DocentesRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Docentes>> GetAllDocentes()
        {
            var docentes = await _contexto.Docentes.ToListAsync();
            return docentes;
        }

        public async Task<Docentes> GetDocenteById(int id)
        {
            var docenteID = await _contexto.Docentes.FirstOrDefaultAsync(x => x.Id == id);

            if(docenteID != null)
            {
                return docenteID;
            }
            throw new Exception("No existe el docente");
        }

        public async Task<Docentes> PostDocente([FromBody] NuevoDocenteQuery query)
        {
            var docentenuevo = new Docentes
            {
                Id = query.Id,
                Nombre = query.Nombre,
                Apellido = query.Apellido,
                Legajo = query.Legajo,
                IdRoles = query.IdRoles
            };

            await _contexto.Docentes.AddAsync(docentenuevo);
            await _contexto.SaveChangesAsync();

            return docentenuevo;
        }

        public async Task<Docentes> PutDocente([FromBody] NuevoDocenteQuery query)
        {
            var DocenteExistente = await _contexto.Docentes.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (DocenteExistente == null)
            {
                return null;
            }

            DocenteExistente.Nombre = query.Nombre;
            DocenteExistente.Apellido = query.Apellido;
            DocenteExistente.Legajo = query.Legajo;
            DocenteExistente.IdRoles = query.IdRoles;

            _contexto.Docentes.Update(DocenteExistente);
            await _contexto.SaveChangesAsync();

            return DocenteExistente;
        }
        public async Task<bool> DeleteDocente(int id)
        {
            var DocenteExistente = await _contexto.Docentes.FirstOrDefaultAsync(x => x.Id == id);

            if (DocenteExistente == null)
            {
                return false;
            }

            _contexto.Docentes.Remove(DocenteExistente);

            await _contexto.SaveChangesAsync();

            return true;
        }

    }
}
