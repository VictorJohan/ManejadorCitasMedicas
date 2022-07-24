using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Medico
    {
        public int MedicoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public int EspecialidadId { get; set; }
        public bool Activo { get; set; }
    }
}
