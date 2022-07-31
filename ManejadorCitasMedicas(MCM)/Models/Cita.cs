using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public class Cita
    {

        public int CitaId { get; set; }
        public string Descripcion { get; set; } = null!;

        public DateTime Inicia { get; set; } = DateTime.Now;
        public DateTime Termina { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar un paciente.")]
        public int PacienteId { get; set; }
        [NotMapped]
        public string NombrePaciente { get; set; }
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar un médico.")]
        public int MedicoId { get; set; }
        [NotMapped]
        public string NombreMedico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public bool Activo { get; set; } = true;
    }
}
