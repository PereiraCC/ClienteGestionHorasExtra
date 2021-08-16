using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class ControlTiempo : Controller
    {
        private Api api = new Api(@"http://localhost/ApiGestionHorasExtra/api");


        public IActionResult Pendientes(ModelFormularioTiempo f)
        {
            List<ModelFormularioTiempo> formularios = new List<ModelFormularioTiempo>();

            if (f.Email != null)
            {

                formularios = api.ObtenerFormulariosTiempo(f.Email, "/FormulariosTiempo");
                if (formularios.Count >= 1)
                {
                    formularios[0].funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                }
                else
                {
                    ModelFormularioTiempo tempFor = new ModelFormularioTiempo();
                    tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                    formularios.Add(tempFor);
                }
            }
            else
            {
                ModelFormularioTiempo tempFor = new ModelFormularioTiempo();
                tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                formularios.Add(tempFor);
            }

            return View(formularios);
        }

        [HttpPost]
        public IActionResult obtenerFormularios(List<ModelFormularioTiempo> f)
        {
            return RedirectToAction("Pendientes", new ModelFormularioTiempo() 
            { 
                Email = f[0].Email
            });
        }

        [HttpPost]
        public IActionResult Pendientes(List<ModelFormularioTiempo> f)
        {
            string res = api.ConnectPOST(f[0].formularioPago.ToJsonString(), "/FormulariosPagos");
            return RedirectToAction("Pendientes", new ModelFormularioTiempo()
            {
                Email = f[0].Email
            });
        }

        public IActionResult Jornadas()
        {
            return View();
        }
    }
}
