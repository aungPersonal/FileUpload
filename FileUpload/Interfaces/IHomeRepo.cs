using FileUpload.Dtos.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Interfaces
{
    public interface IHomeRepo
    {
        Task<IndexResponse> PostIndex(IndexRequest req);
    }
}
