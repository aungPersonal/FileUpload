using FileUpload.Dtos.TransactionApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.API.Interfaces
{
    public interface ITransactionApiRepo
    {
        Task<GetTransactionsResponse> GetTransactions(GetTransactionsRequest req);
    }
}
