using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Citas
    {
        public int CitaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Inicia { get; set; } = DateTime.Now;
        public DateTime Termina { get; set; } = DateTime.Now;
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public int UsuarioCreacion { get; set; }
        [NotMapped]
        public string NombrePaciente { get; set; } = "";
        [NotMapped]
        public string NombreMedico { get; set; } = "";
        [NotMapped]
        public string NombreUsuarioCreacion { get; set; } = "";
        public int UsuarioModificacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
