using API_TP.Data;
using API_TP.Interfaces;
using API_TP.Interfaces.ICursos;
using API_TP.Interfaces.IDocentes;
using API_TP.Mappings;
using API_TP.Repository;
using API_TP.Services.Alumnos;
using API_TP.Services.Cursos;
using API_TP.Services.Docente;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ContextTP>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Conexion"));
});


builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoServices, AlumnoSerivce>();

builder.Services.AddScoped<IDocenteRepository, DocentesRepository>();
builder.Services.AddScoped<IDocenteServices, DocenteService>();

builder.Services.AddScoped<ICursoRepository, CursosRepository>();
builder.Services.AddScoped<ICursoServices, CursoService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
