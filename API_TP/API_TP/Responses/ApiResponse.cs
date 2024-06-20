using System.Net;

namespace API_TP.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string MensajeError { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiResponse()
        {
            Success = true;
            StatusCode = HttpStatusCode.OK;
            MensajeError = "";
        }

        public void SetError(string error, HttpStatusCode status)
        {
            Success = false;
            MensajeError = error;
            StatusCode = status;
        }
    }
}
