using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class Jefatura : Controller
    {
        private Api api = new Api(@"http://localhost/ApiGestionHorasExtra/api");

        [HttpGet]
        public IActionResult EnviarSolicitud()
        {
            ModelTarea tarea = new ModelTarea();
            List<string> data = new List<string>();
            List<Persona> funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
            foreach(Persona p in funcionarios)
            {
                data.Add(p.nombreCompleto);
            }
            tarea.funcionarios = data;
            return View(tarea);
        }

        [HttpPost]
        public IActionResult EnviarSolicitud(ModelTarea tarea)
        {
            tarea.email = getEmail(tarea.email);
            string res = api.ConnectPOST(tarea.ToJsonString(), "/Tareas");
            return RedirectToAction("EnviarSolicitud");
        }

        public IActionResult Evidencias()
        {
            return View();
        }

        public string getEmail(string nombre)
        {
            try
            {
                List<string> data = new List<string>();
                List<Persona> funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                foreach (Persona p in funcionarios)
                {
                    if (p.nombreCompleto.Equals(nombre))
                    {
                        return p.email;
                    }
                }

                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
