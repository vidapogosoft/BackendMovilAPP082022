using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallApi.DTO
{
    public class Registrado
    {

        public int IdRegistrado { get; set; }

        public string Identificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NombresCompletos { get; set; }

        public DateTime? FechaRegistro { get; set; }


    }
}
