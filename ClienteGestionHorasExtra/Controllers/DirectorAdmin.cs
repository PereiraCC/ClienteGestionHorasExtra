using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class DirectorAdmin : Controller
    {
        public IActionResult AprobacionHoras()
        {
            return View();
        }
    }
}
