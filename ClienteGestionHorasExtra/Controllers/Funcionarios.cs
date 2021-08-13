﻿using ClienteGestionHorasExtra.Data;
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
        private Api api = new Api(@"http://localhost/ApiGestionHorasExtra/api");


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
            formularios[0].motivos = motivos;
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

        public IActionResult FormulariosReportes()
        {
            return View();
        }

        public IActionResult Evidencias()
        {
            return View();
        }
    }
}