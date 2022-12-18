using FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Data
{
    public class ConfigTransactionStatusData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigTransactionStatus>().HasData(
                new ConfigTransactionStatus { Id = 1, CSVStatusName = "Approved", XMLStatusName = "Approved", ShortName = "A", CreatedDateTime = DateTime.Parse("2022-12-18 19:12:46.330"), CreatedBy = 1 }
            );

            modelBuilder.Entity<ConfigTransactionStatus>().HasData(
               new ConfigTransactionStatus { Id = 2, CSVStatusName = "Failed", XMLStatusName = "Rejected", ShortName = "R", CreatedDateTime = DateTime.Parse("2022-12-18 19:12:46.330"), CreatedBy = 1 }
           );

            modelBuilder.Entity<ConfigTransactionStatus>().HasData(
             new ConfigTransactionStatus { Id = 3, CSVStatusName = "Finished", XMLStatusName = "Done", ShortName = "D", CreatedDateTime = DateTime.Parse("2022-12-18 19:12:46.330"), CreatedBy = 1 }
            );
        }
    }
}
