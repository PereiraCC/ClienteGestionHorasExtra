using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelFormularioPago
    {
        public int idFormularioPago { get; set; }

        public int idFormularioTiempo { get; set; }

        public string Monto { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }


        public List<Persona> funcionarios { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
