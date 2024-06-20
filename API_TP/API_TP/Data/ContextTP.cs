using API_TP.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TP.Data
{
    public class ContextTP : DbContext
    {
        public ContextTP(DbContextOptions<ContextTP> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Cursos> Cursos { get; set; }

        public DbSet<Carreras> Carreras { get; set; }

        public DbSet<Docentes> Docentes { get; set; }

        public DbSet<Alumnos> Alumnos { get; set; }

        public DbSet<DocentesXCursos> DocentesXcursos { get; set; }

        public DbSet<AlumnosXCursos> AlumnosXCursos { get; set; }



    }
}
