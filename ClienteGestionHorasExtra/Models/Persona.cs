using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class Persona
    {
        public string nombreCompleto { get; set; }

        public string email { get; set; }

        public string pass { get; set; }

        public string departamento { get; set; }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
