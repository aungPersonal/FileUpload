using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Dtos.Home
{
    public class CheckTransactionModel
    {
        public bool IsValid { get; set; } = true;
        public List<CheckTransactionItem> Items { get; set; }
    }

    public class CheckTransactionItem
    {
        public string ErrorMessage { get; set; } = "";
        public InvoiceTransaction InvoiceTransaction { get; set; }
    }
}
