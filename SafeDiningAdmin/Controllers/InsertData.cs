using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;

namespace SafeDiningAdmin.Controllers
{
    public class InsertData : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
