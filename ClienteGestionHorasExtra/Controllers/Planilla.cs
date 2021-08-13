using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class Planilla : Controller
    {
        public IActionResult Pagos()
        {
            return View();
        }
    }
}
