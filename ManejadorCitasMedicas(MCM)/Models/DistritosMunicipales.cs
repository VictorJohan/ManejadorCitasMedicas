using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class DistritosMunicipales
    {
        public int DistritoId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Provincia { get; set; }
        public int Ciudad { get; set; }
    }
}
