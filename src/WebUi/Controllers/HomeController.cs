﻿namespace WebUi.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ErrorViewModel response = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(response);
        }
    }
}