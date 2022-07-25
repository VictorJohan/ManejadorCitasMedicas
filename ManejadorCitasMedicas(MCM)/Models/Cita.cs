using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public class Cita
    {
        public int CitaId { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Inicia { get; set; }
        public DateTime Termina { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
