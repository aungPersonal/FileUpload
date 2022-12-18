using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Models
{
    public class ConfigTransactionStatus
    {
        [Key]
        public int Id { get; set; }
        public string CSVStatusName { get; set; }
        public string XMLStatusName { get; set; }
        public string ShortName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
