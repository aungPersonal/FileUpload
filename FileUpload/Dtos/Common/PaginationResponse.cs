using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.Common
{
    public class PaginationResponse
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int TotalPageCount { get; set; }
    }
}
