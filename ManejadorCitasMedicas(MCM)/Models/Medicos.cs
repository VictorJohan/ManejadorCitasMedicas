using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Medicos
    {
        public int MedicoId { get; set; }
        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string Oficio { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Cargo { get; set; } = "";
        public string Contrasena { get; set; } = "";
        [NotMapped]
        public string NombreEspecialidad { get; set; } = "";
        public int EspecialidadId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
