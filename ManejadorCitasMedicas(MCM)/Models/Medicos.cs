using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Medicos
    {
        public int MedicoId { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Oficio { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        [NotMapped]
        public string NombreEspecialidad { get; set; } = "";
        public int EspecialidadId { get; set; }
        public bool Activo { get; set; }
    }
}
