using FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Data
{
    public class ConfigUploadFileTypeData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigUploadFileType>().HasData(
                new ConfigUploadFileType { Id = 1, Name = "CSV", CreatedDateTime = DateTime.Parse("2022-12-18 19:12:46.330"), CreatedBy = 1 }
            );

            modelBuilder.Entity<ConfigUploadFileType>().HasData(
                new ConfigUploadFileType { Id = 2, Name = "XML", CreatedDateTime = DateTime.Parse("2022-12-18 19:12:46.330"), CreatedBy = 1 }
            );
        }
    }
}
