using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileUpload.Models;
using FileUpload.Consts;
using log4net;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data;
using FileUpload.Interfaces;
using FileUpload.Dtos.Home;

namespace FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IHomeRepo _repo;

        public HomeController(ILogger<HomeController> logger, IHomeRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var res = new IndexResponse();
            res.Message = "";
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexRequest req)
        {

            try
            {
                var res = await _repo.PostIndex(req);
                if(res.CheckTransactionModel.IsValid == false)
                {
                    res.Message = "fail";
                }
                else
                {
                    res.Message = "successfully uploaded";
                }
                return View(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
