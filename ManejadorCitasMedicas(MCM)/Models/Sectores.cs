using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Sectores
    {
        public int SectorId { get; set; }
        public string? Nombre { get; set; }
        public int? Ciudad { get; set; }
        public int Provincia { get; set; }
        public int DistritoId { get; set; }
    }
}
