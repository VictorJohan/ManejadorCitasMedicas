using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Ciudad
    {
        public decimal Id { get; set; }
        public string? Nombre { get; set; }
        public double? Costo { get; set; }
        public int Provincia { get; set; }
        public int IdOrigen { get; set; }
        public bool? Delivery { get; set; }
    }
}
