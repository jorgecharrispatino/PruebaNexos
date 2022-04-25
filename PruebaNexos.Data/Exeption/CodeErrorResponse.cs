using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNexos.Data.Exeption
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message)
        {

            StatusCode = statusCode;
            Message = message ?? GetDefaulMessageStatusCode(statusCode, message);
        }

        private string GetDefaulMessageStatusCode(int statusCode, string message)
        {
            
            switch (statusCode)
            {
                case 400:
                    message = "Bad Request : ¡Error en su solicitud, campos requeridos se encuentran vacíos!";
                    break;
                case 400-1:
                    message = "El autor no está registrado!";
                    break;
                case 404:
                    message = "Not Found : ¡Error en su solicitud, No se encontro registro!";
                    break;
                case 409:
                    message = "Not Found : No es posible registrar el libro, se alcanzó el máximo permitido";
                    break;
                case 500:
                    message = message;
                    break;                    
            }

            return message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
