using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode{get;set;}
        public string? Message{get;set;}

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch{
                400 => "A bad resquest",
                401 => "Authorized, you are not",
                404 => "Resourse not found",
                500 => "Erros are the path to the dark side. Errors lead to anger.",
                _ => null
            };
        }
    }
}