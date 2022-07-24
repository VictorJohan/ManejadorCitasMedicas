using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Sectore
    {
        public decimal Id { get; set; }
        public string? Nombre { get; set; }
        public decimal? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public int Provincia { get; set; }
        public int IdCiudadOrigen { get; set; }
        public int Seccion { get; set; }
        public int DistritoMunicipal { get; set; }
        public int IdOrigen { get; set; }
    }
}
