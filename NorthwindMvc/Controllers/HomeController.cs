using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Packt.Shared;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Northwind db;

        public HomeController(ILogger<HomeController> logger,Northwind injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                VisitorCount = (new Random()).Next(1, 1001),
                Categories = db.Categories.ToList(),
                Products = db.Products.ToList()
            };
            return View(model);// pass model to view
        }

        // 通过筛选器自定义路由
        [Route("private")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        // 使用筛选器保护操作方法。
        //[Authorize(Roles ="Sales,Marketing")]
        //public IActionResult SalesAndMarketingEmployeesOnly()
        //{
        //    return View();
        //}


        // 通过筛选器缓存响应
        //[ResponseCache(Duration =3600,// in seconds=1 hour
        //    Location =ResponseCacheLocation.Any)
        //    ]
        //public IActionResult AboutUs()
        //{
        //    return View();
        //}
    }
}
