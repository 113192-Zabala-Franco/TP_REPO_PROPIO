using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Interfaces.ICursos;
using API_TP.Query.Cursos;
using API_TP.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Services.Cursos
{
    public class CursoService : ICursoServices
    {
        private readonly ICursoRepository _repository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<CursosDto>>> GetAllCursos()
        {
            var response = new ApiResponse<List<CursosDto>>();
            var cursos = await _repository.GetAllCursos();

            if (cursos != null)
            {
                response.Data = _mapper.Map<List<CursosDto>>(cursos);
                return response;
            }
            throw new Exception("No se encontraron Cursos");
        }
        public async Task<ApiResponse<CursosDto>> GetCursoById(int id)
        {
            var respuesta = new ApiResponse<CursosDto>();
            var curso = await _repository.GetCursoById(id);
            respuesta.Data = _mapper.Map<CursosDto>(curso);

            return respuesta;
        }
        public async Task<ApiResponse<CursosDto>> PostCurso([FromBody] NuevoCursoQuery query)
        {
            var response = new ApiResponse<CursosDto>();
            var curso = await _repository.PostCurso(query);
            response.Data = _mapper.Map<CursosDto>(curso);

            return response;
        }
       
        public async Task<ApiResponse<CursosDto>> PutCurso([FromBody] NuevoCursoQuery query)
        {
            var respuesta = new ApiResponse<CursosDto>();

            var cursoActualizado = await _repository.PutCurso(query);

            if (cursoActualizado == null)
            {
                respuesta.Success = false;
                respuesta.MensajeError = "Curso no encontrado";
                return respuesta;
            }

            respuesta.Data = _mapper.Map<CursosDto>(cursoActualizado);
            respuesta.Success = true;
            respuesta.MensajeError = "Curso actualizado correctamente";

            return respuesta;
        }
        public async Task<ApiResponse<bool>> DeleteCursoById(int id)
        {
            var response = new ApiResponse<bool>();
            var result = await _repository.DeleteCurso(id);

            if (!result)
            {
                response.Success = false;
                response.MensajeError = "Curso no encontrado";
                response.Data = false;
                return response;
            }

            response.Success = true;
            response.MensajeError = "Curso eliminado correctamente";
            response.Data = true;

            return response;
        }
    }
}
