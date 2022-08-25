﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Model.APP.Models.Database
{
    public partial class Registrado
    {
        public int IdRegistrado { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombresCompletos { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
