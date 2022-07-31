using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Medico
    {
        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Oficio { get; set; }
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public int EspecialidadId { get; set; }
        [NotMapped]
        public string NombreEspecialidad { get; set; }
        public bool Activo { get; set; }
    }
}
