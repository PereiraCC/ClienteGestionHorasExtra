using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class DirectorAdmin : Controller
    {
        private Api api = new Api(@"http://localhost/ApiGestionHorasExtra/api");

        [HttpGet]
        public IActionResult AprobacionHoras(ModelFormularioAvalado f)
        {
            List<ModelFormularioAvalado> formularios = new List<ModelFormularioAvalado>();

            if (f.Email != null)
            {
                formularios = api.ObtenerFormulariosAvaladosPendientes(f.Email, "/FormulariosAvalados/obtenerFormulariosAvaladosPendientes");
                if (formularios.Count >= 1)
                {
                    formularios[0].funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                }
                else
                {
                    ModelFormularioAvalado tempFor = new ModelFormularioAvalado();
                    tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                    formularios.Add(tempFor);
                }

            }
            else
            {
                ModelFormularioAvalado tempFor = new ModelFormularioAvalado();
                tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                formularios.Add(tempFor);
            }

            return View(formularios);
        }

        [HttpPost]
        public IActionResult obtenerFormularios(List<ModelFormularioAvalado> f)
        {
            return RedirectToAction("AprobacionHoras", new ModelFormularioAvalado
            {
                Email = f[0].funcionarios[0].email
            });
        }

        [HttpPost]
        public IActionResult AprobacionHoras(List<ModelFormularioAvalado> f)
        {
            string res = api.ConnectPOST(f[0].formularioTiempo.ToJsonString(), "/FormulariosTiempo");
            return RedirectToAction("AprobacionHoras", new ModelFormularioAvalado
            {
                Email = f[0].Email
            });
        }
    }
}
