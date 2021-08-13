using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class HomeController : Controller
    {
        private Api api = new Api(@"http://localhost/ApiGestionHorasExtra/api");
        //private string URL_API = "http://localhost/WebApiMatricula/api/Usuarios/Estudiantes";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Persona persona)
        {
            string res = api.InicioSesion(persona.ToJsonString(), "/Personas/Login");

            string[] data = res.Split(',');

            if (data[0].Equals("1"))
            {
                data[1] = data[1].Replace('\"', '@');
                data[1] = data[1].Replace("@", "");

                data[3] = data[3].Replace('\"', '@');
                data[3] = data[3].Replace("@", "");

                Usuario.nombreCompleto = data[1];
                Usuario.email = data[2];
                switch (data[3])
                {
                    case "Jefatura":
                        return RedirectToAction("EnviarSolicitud", "Jefatura");

                    case "Funcionario":
                        return RedirectToAction("Tareas", "Funcionarios");

                    case "Director Administrativo":
                        return RedirectToAction("AprobacionHoras", "DirectorAdmin");

                    case "Encargado de Control":
                        return RedirectToAction("Pendientes", "ControlTiempo");

                    case "Encargado de Planilla":
                        return RedirectToAction("Pagos", "Planilla");

                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                //Estudiante es = new Estudiante();
                //es.tiposIdentificacion = cargarTiposUsuario();
                //ViewBag.error = res;
                return View();
            }
        }

        [HttpGet]
        public IActionResult SingOut()
        {
            Persona p = new Persona()
            {
                email = Usuario.email
            };
            string res = api.CerrarSesion(p.ToJsonString(), "/Personas/SingOut");

            if (res.Equals("1"))
            {
                Usuario.nombreCompleto = null;
                Usuario.email = null;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Estudiante es = new Estudiante();
                //es.tiposIdentificacion = cargarTiposUsuario();
                //ViewBag.error = res;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Persona persona)
        {
            string res = api.ConnectPOST(persona.ToJsonString(), "/Personas");

            if (res.Equals("1"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Estudiante es = new Estudiante();
                //es.tiposIdentificacion = cargarTiposUsuario();
                //ViewBag.error = res;
                return View();
            }
        }
    }
}
