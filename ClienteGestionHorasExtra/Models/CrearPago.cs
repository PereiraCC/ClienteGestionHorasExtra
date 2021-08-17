using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class ModelPago
    {
        public int idPago { get; set; }

        public int idSolicitud { get; set; }

        public int idFormularioAvalado { get; set; }

        public int idFormularioTiempo { get; set; }

        public int idFormularioPago { get; set; }

        public int Monto { get; set; }

        public string TipoPago { get; set; }

        public bool Estado { get; set; }

        public int HorasValidas { get; set; }


        public string NombreCompleto { get; set; }

        public string QUINCENA { get; set; }

        public string Descripcion { get; set; }

        public string Email { get; set; }

        public string RutaArchivo { get; set; }

        public string Motivo { get; set; }

        public DateTime FechaEnvio { get; set; }

        public List<Persona> funcionarios { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
