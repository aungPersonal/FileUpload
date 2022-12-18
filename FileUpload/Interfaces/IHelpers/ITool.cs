using FileUpload.Dtos.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Interfaces.IHelpers
{
    public interface ITool
    {
        Task<DataTable> CSVToDataTable(string csvData);
        Task<CheckTransactionModel> CheckTransaction(DataTable dt);
    }
}
