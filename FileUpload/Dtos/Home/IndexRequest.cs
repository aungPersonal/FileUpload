using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.Home
{
    public class IndexRequest
    {
        [Required]
        public IFormFile PostedFile { get; set; }
    }
}
