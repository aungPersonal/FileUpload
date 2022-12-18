using FileUpload.Data;
using FileUpload.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Context
{
    public class FileUploadContext : DbContext
    {
        public FileUploadContext()
        {

        }

        public FileUploadContext(DbContextOptions<FileUploadContext> options) : base(options)
        {
        }

        public DbSet<ConfigUploadFileType> ConfigUploadFileType { get; set; }
        public DbSet<ConfigTransactionStatus> ConfigTransactionStatus { get; set; }
        public DbSet<InvoiceTransaction> InvoiceTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            ConfigTransactionStatusData.Seed(modelBuilder);
            ConfigUploadFileTypeData.Seed(modelBuilder);
        }

    }
}
