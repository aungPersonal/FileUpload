using FileUpload.Consts;
using FileUpload.Dtos.Home;
using FileUpload.Enums;
using FileUpload.Interfaces.IHelpers;
using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Helpers
{
    public class Tool : ITool
    {
        public async Task<DataTable> CSVToDataTable(string csvData)
        {
            DataTable dt = new DataTable();
            bool firstRow = true;
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (firstRow)
                        {
                            foreach (string cell in row.Split(','))
                            {
                                dt.Columns.Add(cell.Trim());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split(','))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                i++;
                            }
                        }
                    }
                }
            }

            return dt;
        }

        public async Task<CheckTransactionModel> CheckTransaction(DataTable dt)
        {
            try
            {
                CheckTransactionModel res = new CheckTransactionModel();
                res.Items = new List<CheckTransactionItem>();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CheckTransactionItem item = new CheckTransactionItem();
                        item.InvoiceTransaction = new InvoiceTransaction();
                        item.InvoiceTransaction.Id = dt.Rows[i]["Transaction Identificator"].ToString();
                        if (string.IsNullOrEmpty(item.InvoiceTransaction.Id))
                        {
                            item.ErrorMessage += $"Transaction Identificator is required.";
                            res.IsValid = false;
                        }
                        try
                        {
                            item.InvoiceTransaction.Amount = Convert.ToDouble(dt.Rows[i]["Amount"].ToString());
                            if (item.InvoiceTransaction.Amount == 0)
                            {
                                item.ErrorMessage += $"Amount is required.";
                                res.IsValid = false;
                            }
                        }
                        catch
                        {
                            item.ErrorMessage += $"Amount is invalid.";
                            res.IsValid = false;
                        }

                        item.InvoiceTransaction.CurrencyCode = dt.Rows[i]["Currency Code"].ToString();
                        if (string.IsNullOrEmpty(item.InvoiceTransaction.CurrencyCode))
                        {
                            item.ErrorMessage += $"Currency code is required.";
                            res.IsValid = false;
                        }

                        try
                        {
                            item.InvoiceTransaction.TransactionDateTime = Convert.ToDateTime(dt.Rows[i]["Transaction Date"].ToString());
                            if (item.InvoiceTransaction.TransactionDateTime == new DateTime())
                            {
                                item.ErrorMessage += $"Transaction Date is required.";
                                res.IsValid = false;
                            }
                        }
                        catch
                        {
                            item.ErrorMessage += $"Transaction Date is invalid.";
                            res.IsValid = false;
                        }

                        string ConfigTransactionStatus = dt.Rows[i]["Status"].ToString();
                        if (string.IsNullOrEmpty(item.InvoiceTransaction.CurrencyCode))
                        {
                            item.ErrorMessage += $"Status is required.";
                            res.IsValid = false;
                        }
                        item.InvoiceTransaction.ConfigTransactionStatusId = GetTransactionStatus(ConfigTransactionStatus);
                        if(item.InvoiceTransaction.ConfigTransactionStatusId == 0)
                        {
                            item.ErrorMessage += $"Status is invalid.";
                            res.IsValid = false;
                        }

                        res.Items.Add(item);
                    }

                }
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetTransactionStatus(string status)
        {
            if(status == Const.TransactionCSVStatus_Approved)
            {
                return (int) TransactionCSVStatus.Approved;
            }

            if (status == Const.TransactionCSVStatus_Failed)
            {
                return (int)TransactionCSVStatus.Failed;
            }

            if (status == Const.TransactionCSVStatus_Finished)
            {
                return (int)TransactionCSVStatus.Finished;
            }

            return 0;
        }
    }
}
