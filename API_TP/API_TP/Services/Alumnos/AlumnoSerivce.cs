using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Models;
using AutoMapper;
using API_TP.Responses;
using Microsoft.AspNetCore.Mvc;
using API_TP.Query.Alumnos;

namespace API_TP.Services.Alumnos
{
    public class AlumnoSerivce : IAlumnoServices
    {
        private readonly IAlumnoRepository _repository;
        private readonly IMapper _mapper;

        public AlumnoSerivce(IAlumnoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<AlumnosDto>>> GetAllAlumnos()
        {
            var response = new ApiResponse<List<AlumnosDto>>();
            var alumnos = await _repository.GetAllAlumnos();

            if (alumnos != null)
            {
                response.Data = _mapper.Map<List<AlumnosDto>>(alumnos);
                
                return response;
            }
            throw new Exception("No se encontraron Alumnos");
        }


        public async Task<ApiResponse<AlumnosDto>> GetAlumnoById(int id)
        {
            var respuesta = new ApiResponse<AlumnosDto>();
            var alumno = await _repository.GetAlumnosById(id);
            respuesta.Data = _mapper.Map<AlumnosDto>(alumno);

            return respuesta;
        }

        public async Task<ApiResponse<AlumnosDto>> PostAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var response = new ApiResponse<AlumnosDto>();
            var alumno = await _repository.PostAlumno(query);
            response.Data = _mapper.Map<AlumnosDto>(alumno);

            return response;
        }


        public async Task<ApiResponse<AlumnosDto>> PutAlumno([FromBody] NuevoAlumnoQuery query)
        {
            var respuesta = new ApiResponse<AlumnosDto>();

            var alumnoActualizado = await _repository.PutAlumno(query);

            if (alumnoActualizado == null)
            {
                respuesta.Success = false;
                respuesta.MensajeError = "Alumno no encontrado";
                return respuesta;
            }

            respuesta.Data = _mapper.Map<AlumnosDto>(alumnoActualizado);
            respuesta.Success = true;
            respuesta.MensajeError = "Alumno actualizado correctamente";

            return respuesta;
        }

        public async Task<ApiResponse<bool>> DeleteAlumnoById(int id)
        {
            var response = new ApiResponse<bool>();
            var result = await _repository.DeleteAlumno(id);

            if (!result)
            {
                response.Success = false;
                response.MensajeError = "Alumno no encontrado";
                response.Data = false;
                return response;
            }

            response.Success = true;
            response.MensajeError = "Alumno eliminado correctamente";
            response.Data = true;

            return response;
        }

    }
}
