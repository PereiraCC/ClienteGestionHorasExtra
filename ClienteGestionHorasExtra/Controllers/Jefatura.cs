using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Hosting;
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

        private IHostingEnvironment _env;

        public Jefatura(IHostingEnvironment env)
        {
            _env = env;
        }

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

        [HttpGet]
        public IActionResult Evidencias(Persona p)
        {
            List<ModelEvidencias> evidencias = new List<ModelEvidencias>();

            if (p.email != null)
            {
                evidencias = api.ObtenerEvidenciasFuncionario(p.email, "/Evidencias");
                if(evidencias.Count >= 1)
                {
                    evidencias[0].funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                }
                else
                {
                    ModelEvidencias tempEvi = new ModelEvidencias();
                    tempEvi.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                    evidencias.Add(tempEvi);
                }
               
            }
            else
            {
                ModelEvidencias tempEvi = new ModelEvidencias();
                tempEvi.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                evidencias.Add(tempEvi);
            }
            
            return View(evidencias);
        }

        [HttpPost]
        public IActionResult Evidencias(List<ModelEvidencias> e)
        {
            string res = api.AceptarEvidencia(e[0].idEvidencia, "/Evidencias/AceptarEvidencia");
            return RedirectToAction("Evidencias", new Persona
            {
                email = getEmail(e[0].idPersona)
            });
        }

        [HttpPost]
        public FileResult DescargarArchivo(List<ModelEvidencias> e)
        {
            var webRoot = _env.WebRootPath;
            var file = System.IO.Path.Combine(webRoot, e[0].RutaDocumento);
            return File(file, "application/pdf", "Evidencia.pdf");

        }

        [HttpPost]
        public IActionResult obtenerEvidencias(List<ModelEvidencias> e)
        {
            return RedirectToAction("Evidencias", new Persona{ 
                email = e[0].funcionarios[0].email
            });
        }

        [HttpGet]
        public IActionResult Solicitudes()
        {
            return View(api.ObtenerSolicitudesTareas("/Solicitud"));
        }

        [HttpPost]
        public IActionResult AceptarSolicitud(List<ModelTarea> tareas)
        {
            string res = api.AceptarSolicitud(tareas[0].Motivo, "/Solicitud/AceptarSolicitud");
            return RedirectToAction("Solicitudes");
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

        public string getEmail(int idPersona)
        {
            try
            {
                List<string> data = new List<string>();
                List<Persona> funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                foreach (Persona p in funcionarios)
                {
                    if (p.idPersona.Equals(idPersona))
                    {
                        return p.email;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
