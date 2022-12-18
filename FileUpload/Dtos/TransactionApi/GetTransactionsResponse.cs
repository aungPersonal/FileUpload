using FileUpload.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.TransactionApi
{
    public class GetTransactionsResponse : PaginationResponse
    {
        public List<GetTransactionsItem> Items { get; set; }
    }

    public class GetTransactionsItem
    {
        public string Id { get; set; }
        public string payment { get; set; }
       
        public string Status { get; set; }
    }
}
