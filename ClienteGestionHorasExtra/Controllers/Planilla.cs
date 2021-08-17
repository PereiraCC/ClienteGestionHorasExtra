using ClienteGestionHorasExtra.Data;
using ClienteGestionHorasExtra.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Controllers
{
    public class Planilla : Controller
    {
        private Api api = new Api(@"http://api.gestionhoraextra.com/api");

        [HttpGet]
        public IActionResult Pagos(ModelPago f)
        {
            List<ModelPago> formularios = new List<ModelPago>();

            if (f.Email != null)
            {

                formularios = api.ObtenerFormulariosPago(f.Email, "/FormulariosPagos");
                if (formularios.Count >= 1)
                {
                    formularios[0].funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                }
                else
                {
                    ModelPago tempFor = new ModelPago();
                    tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                    formularios.Add(tempFor);
                }
            }
            else
            {
                ModelPago tempFor = new ModelPago();
                tempFor.funcionarios = api.ObtenerFuncionarios("/Personas/GetFuncionarios");
                formularios.Add(tempFor);
            }

            return View(formularios);

        }

        [HttpPost]
        public IActionResult obtenerPagos(List<ModelPago> f)
        {
            return RedirectToAction("Pagos", new ModelPago()
            {
                Email = f[0].Email
            });
        }

        [HttpPost]
        public IActionResult Pagos(List<ModelPago> f)
        {
            string res = api.ConnectPOST(f[0].ToJsonString(), "/Pagos");
            return RedirectToAction("Pagos", new ModelPago()
            {
                Email = f[0].Email
            });

        }
    }
}
