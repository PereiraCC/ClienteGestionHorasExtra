using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelTarea
    {
        public string email { get; set; }
        public string Motivo { get; set; }

        public int idSolicitud { get; set; }

        public DateTime entrada { get; set; }

        public DateTime Salida { get; set; }

        public DateTime Fecha { get; set; }

        public int Horas { get; set; }

        public bool Estado { get; set; }

        public List<string> funcionarios { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
