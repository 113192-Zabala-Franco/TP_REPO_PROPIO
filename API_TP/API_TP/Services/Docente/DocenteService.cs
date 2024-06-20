using API_TP.DTOS;
using API_TP.Interfaces;
using API_TP.Interfaces.IDocentes;
using API_TP.Query.Docentes;
using API_TP.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_TP.Services.Docente
{
    public class DocenteService : IDocenteServices
    {
        private readonly IDocenteRepository _repository;
        private readonly IMapper _mapper;

        public DocenteService(IDocenteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public async Task<ApiResponse<List<DocentesDto>>> GetAllDocentes()
        {
            var response = new ApiResponse<List<DocentesDto>>();
            var docentes = await _repository.GetAllDocentes();

            if (docentes != null)
            {
                response.Data = _mapper.Map<List<DocentesDto>>(docentes);
                return response;
            }
            throw new Exception("No se encontraron Docentes");
        }

        public async Task<ApiResponse<DocentesDto>> GetDocenteById(int id)
        {
            var respuesta = new ApiResponse<DocentesDto>();
            var docente = await _repository.GetDocenteById(id);
            respuesta.Data = _mapper.Map<DocentesDto>(docente);

            return respuesta;
        }

        public async Task<ApiResponse<DocentesDto>> PostDocente([FromBody] NuevoDocenteQuery query)
        {
            var response = new ApiResponse<DocentesDto>();
            var docente = await _repository.PostDocente(query);
            response.Data = _mapper.Map<DocentesDto>(docente);

            return response;
        }

        public async Task<ApiResponse<DocentesDto>> PutDocente([FromBody] NuevoDocenteQuery query)
        {
            var respuesta = new ApiResponse<DocentesDto>();

            var docenteActualizado = await _repository.PutDocente(query);

            if (docenteActualizado == null)
            {
                respuesta.Success = false;
                respuesta.MensajeError = "Docente no encontrado";
                return respuesta;
            }

            respuesta.Data = _mapper.Map<DocentesDto>(docenteActualizado);
            respuesta.Success = true;
            respuesta.MensajeError = "Docente actualizado correctamente";

            return respuesta;
        }

        public async Task<ApiResponse<bool>> DeleteDocenteById(int id)
        {
            var response = new ApiResponse<bool>();
            var result = await _repository.DeleteDocente(id);

            if (!result)
            {
                response.Success = false;
                response.MensajeError = "Docente no encontrado";
                response.Data = false;
                return response;
            }

            response.Success = true;
            response.MensajeError = "Docente eliminado correctamente";
            response.Data = true;

            return response;
        }
    }
}
