using FileUpload.Context;
using FileUpload.Dtos.Home;
using FileUpload.Enums;
using FileUpload.Interfaces;
using FileUpload.Interfaces.IHelpers;
using FileUpload.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Repos
{
    public class HomeRepo : IHomeRepo
    {
        private readonly ITool _tool;
        private readonly FileUploadContext _context;
        public HomeRepo(ITool tool, FileUploadContext context)
        {
            _tool = tool;
            _context = context;
        }
        public async Task<IndexResponse> PostIndex(IndexRequest req)
        {
            try
            {
                var res = new IndexResponse();

                if (req.PostedFile != null)
                {

                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileName(req.PostedFile.FileName);
                    string filePath = Path.Combine(path, fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        req.PostedFile.CopyTo(stream);
                    }
                    string csvData = System.IO.File.ReadAllText(filePath);
                    DataTable dt = await _tool.CSVToDataTable(csvData);
                    var checkRes = await _tool.CheckTransaction(dt);

                    if(checkRes.IsValid == false)
                    {
                        res.StatusCode = StatusCodes.Status400BadRequest;
                        res.CheckTransactionModel = checkRes;
                        return res;
                    }
                    else
                    {
                        //save transaction
                        using (var transaction = _context.Database.BeginTransaction())
                        {

                            try
                            {
                                long uploadedSerialNo = _context.InvoiceTransaction.OrderByDescending(x => x.UploadedGpSerialNo).Select(x => x.UploadedGpSerialNo).FirstOrDefault() ?? 0;
                                uploadedSerialNo++;

                                foreach (var invoice in checkRes.Items)
                                {
                                    var tranInvoice = invoice.InvoiceTransaction;
                                    var invoiceTransaction = new InvoiceTransaction();
                                    invoiceTransaction.Id = tranInvoice.Id;
                                    invoiceTransaction.Amount = tranInvoice.Amount;
                                    invoiceTransaction.CurrencyCode = tranInvoice.CurrencyCode;
                                    invoiceTransaction.TransactionDateTime = tranInvoice.TransactionDateTime;
                                    invoiceTransaction.ConfigTransactionStatusId = tranInvoice.ConfigTransactionStatusId;
                                    invoiceTransaction.UploadedGpSerialNo = uploadedSerialNo;
                                    invoiceTransaction.ConfigUploadFileTypeId = (int) ConfigUploadFileTypeId.CSV;
                                    invoiceTransaction.UploadedDateTime = DateTime.Now;
                                    invoiceTransaction.CreatedBy = 1; //logined user
                                    invoiceTransaction.CreatedDateTime = DateTime.Now;
                                    _context.InvoiceTransaction.Add(invoiceTransaction);
                                }
                                await _context.SaveChangesAsync();
                                await transaction.CommitAsync();
                            }
                            catch (Exception e)
                            {
                              
                                transaction.Rollback();
                                throw e;
                            }
                        }
                    }

                    res.CheckTransactionModel = checkRes;
                    return res;
                }
                else
                {
                    res.StatusCode = StatusCodes.Status400BadRequest;
                    res.Message = "File is required";
                    return res;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
