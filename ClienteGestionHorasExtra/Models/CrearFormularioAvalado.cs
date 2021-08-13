using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class CrearFormularioAvalado
    {
        public string Motivo { get; set; }
        public DateTime Envio { get; set; }
        public string Mes { get; set; }
        public int Hora { get; set; }
        public string Ruta { get; set; }

        //public IFormFile Archivo { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

    }
}
