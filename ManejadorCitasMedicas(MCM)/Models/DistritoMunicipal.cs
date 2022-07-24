using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class DistritoMunicipal
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Provincia { get; set; }
        public int Ciudad { get; set; }
        public int IdCuidadOrigen { get; set; }
        public int IdOrigen { get; set; }
    }
}
