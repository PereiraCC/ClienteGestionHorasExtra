using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class Jefatura : Controller
    {
        public IActionResult EnviarSolicitud()
        {
            return View();
        }

        public IActionResult Evidencias()
        {
            return View();
        }
    }
}
