using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelFormularioTiempo
    {
        public int idFormularioTiempo { get; set; }

        public int idFormularioAvalado { get; set; }

        public int HorasValidas { get; set; }

        public string QUINCENA { get; set; }

        public bool Estado { get; set; }

        public System.DateTime FechaEnvio { get; set; }

        public string Motivo { get; set; }

        public string Email { get; set; }

        public string RutaArchivo { get; set; }
        

        public List<Persona> funcionarios { get; set; }

        public ModelFormularioPago formularioPago { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
