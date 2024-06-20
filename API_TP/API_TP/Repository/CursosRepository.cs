using API_TP.Data;
using API_TP.DTOS;
using API_TP.Interfaces.ICursos;
using API_TP.Models;
using API_TP.Query.Alumnos;
using API_TP.Query.Cursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TP.Repository
{
    public class CursosRepository : ICursoRepository
    {
        private readonly ContextTP _contexto;

        public CursosRepository(ContextTP contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Cursos>> GetAllCursos()
        {
            var cursos = await _contexto.Cursos.ToListAsync();
            return cursos;
        }

        public async Task<Cursos> GetCursoById(int id)
        {
            var cursoId = await _contexto.Cursos.FirstOrDefaultAsync(x => x.Id == id);
            return cursoId;
        }

        public async Task<Cursos> PostCurso(NuevoCursoQuery query)
        {
            var cursoNuevo = new Cursos
            {
                Id = query.Id,
                Nombre = query.Nombre,
                FechaCreacion = DateTime.UtcNow,
                Horarios = query.Horarios,
                IdCarrera = query.IdCarrera,
            };

            await _contexto.Cursos.AddAsync(cursoNuevo);
            await _contexto.SaveChangesAsync();

            return cursoNuevo;
        }

        public async Task<Cursos> PutCurso([FromBody] NuevoCursoQuery query)
        {
            var cursoExistente = await _contexto.Cursos.FirstOrDefaultAsync(x => x.Id == query.Id);

            if (cursoExistente == null)
            {
                return null;
            }

            cursoExistente.Id = query.Id;
            cursoExistente.Nombre = query.Nombre;
            cursoExistente.Horarios = query.Horarios;
            cursoExistente.IdCarrera = query.IdCarrera;

            _contexto.Cursos.Update(cursoExistente);
            await _contexto.SaveChangesAsync();

            return cursoExistente;
        }

        public async Task<bool> DeleteCurso(int id)
        {
            var cursoExistente = await _contexto.Cursos.FirstOrDefaultAsync(x => x.Id == id);

            if (cursoExistente == null)
            {
                return false;
            }

            _contexto.Cursos.Remove(cursoExistente);

            await _contexto.SaveChangesAsync();

            return true;
        }
    }
}
