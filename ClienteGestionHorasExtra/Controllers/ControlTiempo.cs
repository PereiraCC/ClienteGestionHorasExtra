using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class ControlTiempo : Controller
    {
        public IActionResult Pendientes()
        {
            return View();
        }

        public IActionResult Jornadas()
        {
            return View();
        }
    }
}
