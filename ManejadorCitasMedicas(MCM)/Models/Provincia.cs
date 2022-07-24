using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Provincia
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Activa { get; set; }
    }
}
