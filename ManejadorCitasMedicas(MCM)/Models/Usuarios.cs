using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage =" Este campo es obligatorio."), MaxLength(50, ErrorMessage = "Longitud máxima alcanzada")]
        public string Nombre { get; set; } = "";
        [Required(ErrorMessage = " Este campo es obligatorio."), MaxLength(50, ErrorMessage = "Longitud máxima alcanzada")]
        public string Apellido { get; set; } = "";
        [Required(ErrorMessage = " Este campo es obligatorio."), MaxLength(50, ErrorMessage = "Longitud máxima alcanzada")]
        public string NombreUsuario { get; set; } = "";
        [Required(ErrorMessage = " Este campo es obligatorio.")]
        public string Contrasena { get; set; } = "";
        [Compare("Contrasena", ErrorMessage = "Las contraseñas no coinciden.")]
        [NotMapped]
        public string ConfirmarContrasena { get; set; } = "";
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; } = false;
    }
}
