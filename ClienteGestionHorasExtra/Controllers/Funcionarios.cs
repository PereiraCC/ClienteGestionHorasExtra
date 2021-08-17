using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ClienteGestionHorasExtra.Controllers
{
    public class Funcionarios : Controller
    {
        private Api api = new Api(@"http://api.gestionhoraextra.com/api");


        [HttpGet]
        public IActionResult Tareas()
        {
            return View(api.ObtenerTareas(Usuario.email, "/Tareas"));
        }

        [HttpGet]
        public IActionResult FormulariosAvalados()
        {
            List<string> motivos = new List<string>();
            List<ModelFormularioAvalado> formularios = api.ObtenerFormulariosAvalados(Usuario.email, "/FormulariosAvalados");
            List<ModelTarea> tareas = api.ObtenerTareas(Usuario.email, "/Tareas");
            foreach(ModelTarea t in tareas)
            {
                motivos.Add(t.Motivo);
            }
            if(formularios.Count >= 1)
            {
                formularios[0].motivos = motivos;
            }
            else
            {
                ModelFormularioAvalado temp = new ModelFormularioAvalado();
                temp.motivos = motivos;
                formularios.Add(temp);
            }
            
            return View(formularios);
        }

        [HttpPost]
        public IActionResult FormulariosAvalados(List<ModelFormularioAvalado> formulario)
        {
            formulario[0].formulario.Envio = DateTime.Now;
            formulario[0].formulario.Ruta = Path.Combine("/Archivos", formulario[0].formulario.Ruta);
            
            //string ruta = Path.Combine(Directory.GetCurrentDirectory() + "/Archivos", formulario[0].formulario.Archivo.FileName);
            //using var stream = new FileStream(ruta, FileMode.Create);
            //formulario[0].formulario.Archivo.CopyToAsync(stream);

            string res = api.ConnectPOST(formulario[0].formulario.ToJsonString(), "/FormulariosAvalados");
            return RedirectToAction("FormulariosAvalados");
        }

        [HttpGet]
        public IActionResult FormulariosReportes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormulariosReportes(ModelTarea tarea)
        {
            tarea.email = Usuario.email;
            string res = api.ConnectPOST(tarea.ToJsonString(), "/Solicitud");
            return RedirectToAction("FormulariosReportes");
        }

        [HttpGet]
        public IActionResult Evidencias()
        {
            return View( new ModelCrearEvidencia()
            {
                tareas = api.ObtenerTareas(Usuario.email, "/Tareas")
            });
        }

        [HttpPost]
        public IActionResult Evidencias(ModelCrearEvidencia evidencia)
        {
            evidencia.RutaDocumento = "/Archivos/Evidencias/" + evidencia.RutaDocumento;
            string res = api.ConnectPOST(evidencia.ToJsonString(), "/Evidencias");
            return RedirectToAction("Evidencias");
        }
    }
}
