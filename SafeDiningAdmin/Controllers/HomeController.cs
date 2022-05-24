using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafeDiningAdmin.Models;

// Programmer Name : Abdullah Maher Abbod Bahaj, Software engineering student, APU, Technology Park Malaysia
// Program Name    : SafeDiningIR
// Description     : To Run the features on the restaurant customer and staff on the FYP document
// First Written on: Monday, 5-Oct-2020
// Edited on       : Tuesday, 22-Dec-2020

namespace SafeDiningAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}