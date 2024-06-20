using API_TP.Data;
using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Models;
using API_TP.Query.Alumnos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TP.Repository
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ContextTP _contexto;

        public AlumnoRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Alumnos>> GetAllAlumnos()
        {
            var alumnos = await _contexto.Alumnos.ToListAsync();
            return alumnos;
        }

        public async Task<Alumnos> GetAlumnosById(int id)
        {
            var alumnoId = await _contexto.Alumnos.FirstOrDefaultAsync(x => x.Id == id);
            return alumnoId;
        }

        public async Task<Alumnos> PostAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var alumnoNuevo = new Alumnos
            {
                Id = query.Id,
                Nombre = query.Nombre,
                Apellido = query.Apellido,
                Legajo = query.Legajo,
                IdRoles = query.IdRol
            };

            await _contexto.Alumnos.AddAsync(alumnoNuevo);
            await _contexto.SaveChangesAsync();

            return alumnoNuevo;
        }

        public async Task<Alumnos> PutAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var alumnoExistente = await _contexto.Alumnos.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (alumnoExistente == null)
            {
                return null;
            }

            alumnoExistente.Nombre = query.Nombre;
            alumnoExistente.Apellido = query.Apellido;
            alumnoExistente.Legajo = query.Legajo;
            alumnoExistente.IdRoles = query.IdRol;

            _contexto.Alumnos.Update(alumnoExistente);
            await _contexto.SaveChangesAsync();

            return alumnoExistente;
        }

        public async Task<bool> DeleteAlumno(int id)
        {
            var alumnoExistente = await _contexto.Alumnos.FirstOrDefaultAsync(x => x.Id == id);

            if (alumnoExistente == null)
            {
                return false; 
            }

            _contexto.Alumnos.Remove(alumnoExistente);

            await _contexto.SaveChangesAsync();

            return true;
        }

    }
}
