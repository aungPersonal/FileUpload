using FileUpload.API.Interfaces;
using FileUpload.Context;
using FileUpload.Dtos.TransactionApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Repos
{
    public class TransactionApiRepo : ITransactionApiRepo
    {
        private readonly FileUploadContext _context;

        public TransactionApiRepo(FileUploadContext context)
        {
            _context = context;
        }
        public async Task<GetTransactionsResponse> GetTransactions(GetTransactionsRequest req)
        {
            try
            {
                int statusId = 0;
                if(req.Status == "A")
                {
                    statusId = 1;
                }
                else if(req.Status == "R")
                {
                    statusId = 2;
                }
                else if(req.Status == "D")
                {
                    statusId = 3;
                }

                var res = new GetTransactionsResponse();
                var items = (
                    from iv in _context.InvoiceTransaction
                    where
                    (string.IsNullOrEmpty(req.Currency) ? true : iv.CurrencyCode == req.Currency) &&
                    (statusId == 0 ? true : iv.ConfigTransactionStatusId == statusId) &&
                    (req.FromTransactionDateTime == null || req.FromTransactionDateTime == new DateTime() ? true : iv.TransactionDateTime >= req.FromTransactionDateTime) &&
                    (req.ToTransactionDateTime == null || req.ToTransactionDateTime == new DateTime() ? true : iv.TransactionDateTime <= req.ToTransactionDateTime)

                    select iv
                    ).Skip((req.PageNumber - 1) * req.PageSize).Take(req.PageSize).ToList();

                res.Items = items.Select(x=> 
                new GetTransactionsItem
                {
                    Id = x.Id,
                    Status = _context.ConfigTransactionStatus.Where(s=> s.Id == x.ConfigTransactionStatusId).Select(s=> s.ShortName).FirstOrDefault(),
                    payment = x.Amount + x.CurrencyCode
                }
                ).ToList();

                res.TotalCount = (
                    from iv in _context.InvoiceTransaction
                    where
                    (string.IsNullOrEmpty(req.Currency) ? true : iv.CurrencyCode == req.Currency) &&
                    (statusId == 0 ? true : iv.ConfigTransactionStatusId == statusId) &&
                    (req.FromTransactionDateTime == null || req.FromTransactionDateTime == new DateTime() ? true : iv.TransactionDateTime >= req.FromTransactionDateTime) &&
                    (req.ToTransactionDateTime == null || req.ToTransactionDateTime == new DateTime() ? true : iv.TransactionDateTime <= req.ToTransactionDateTime)

                    select iv.Id
                    ).Count();

                res.Count = items.Count;
                res.TotalPageCount = (int)Math.Ceiling((double)res.TotalCount / req.PageSize);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
