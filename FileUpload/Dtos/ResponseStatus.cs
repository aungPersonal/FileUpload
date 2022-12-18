using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos
{
    public class ResponseStatus
    {
        public int StatusCode { get; set; } = StatusCodes.Status200OK;
        public string Message { get; set; } = "success";
    }
}
