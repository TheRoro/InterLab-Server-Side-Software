using System;
using InterLab.API.Domain.Models;

namespace InterLab.API.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {

        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            //asumo que es exito
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            //asumo que es error
            Success = false;
            Message = message;
        }
    }
}
