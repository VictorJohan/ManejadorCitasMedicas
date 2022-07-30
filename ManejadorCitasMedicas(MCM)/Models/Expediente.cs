using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public class Expediente
    {
        public int PacienteId { get; set; }
        public string NumeroExpendiente { get; set; } = null!;
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Nota { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
