using FileUpload.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.TransactionApi
{
    public class GetTransactionsRequest : PaginationRequest
    {
        public string Currency { get; set; }
        // Approved = 1, A
        //Failed = 2, R
        //Finished = 3, D
        public string Status { get; set; }
        public DateTime FromTransactionDateTime { get; set; }
        public DateTime ToTransactionDateTime { get; set; }
    }
}
