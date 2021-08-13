using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteGestionHorasExtra.Models
{
    public class SubirArchivo
    {

        public string Descripcion { get; set; }

        public IFormFile Archivo { get; set; }
    }
}
