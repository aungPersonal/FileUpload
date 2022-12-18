using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.API.Interfaces;
using FileUpload.Dtos.TransactionApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        public readonly ITransactionApiRepo _repo;

        public TransactionApiController(ITransactionApiRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetTransactions([FromQuery]GetTransactionsRequest req)
        {
            try
            {
                var res = await _repo.GetTransactions(req);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
