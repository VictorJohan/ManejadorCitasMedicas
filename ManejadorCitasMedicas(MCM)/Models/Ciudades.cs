using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Ciudades
    {
        public decimal CiudadId { get; set; }
        public string? Nombre { get; set; }
        public int ProvinciaId { get; set; }
    }
}
