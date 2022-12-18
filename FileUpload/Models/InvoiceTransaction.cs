using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class InvoiceTransaction
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int ConfigTransactionStatusId { get; set; }
        public DateTime? UploadedDateTime { get; set; }
        public long? UploadedGpSerialNo { get; set; } //uploaded group serial number
        public int? ConfigUploadFileTypeId { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public virtual ConfigTransactionStatus ConfigTransactionStatus { get; set; }
        public virtual ConfigUploadFileType ConfigUploadFileType { get; set; }
    }
}
