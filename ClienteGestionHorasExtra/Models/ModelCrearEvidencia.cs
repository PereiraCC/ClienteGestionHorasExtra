using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelCrearEvidencia
    {
        public string RutaDocumento { get; set; }
        public System.DateTime HoraInicial { get; set; }
        public System.DateTime HoraFinal { get; set; }
        public string Motivo { get; set; }

        public List<ModelTarea> tareas { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
