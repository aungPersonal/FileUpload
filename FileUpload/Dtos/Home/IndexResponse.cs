using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.Home
{
    public class IndexResponse : ResponseStatus
    {
        public CheckTransactionModel CheckTransactionModel { get; set; }
    }
}
