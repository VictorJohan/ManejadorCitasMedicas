using System;
using System.Collections.Generic;

namespace ManejadorCitasMedicas_MCM_.Models
{
    public partial class Pacientes
    {
        public int PacienteId { get; set; }
        public string NumeroExpendiente { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apodo { get; set; } = "";
        public string PrimerApellido { get; set; } = "";
        public string SegundoApellido { get; set; } = "";
        public string Cedula { get; set; } = "";
        public string Nota { get; set; } = "";
        public bool? Activo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        public string Mail { get; set; } = "";
        public string Nss { get; set; } = "";
        public int Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public string Nacionalidad { get; set; } = "";
        public int Ars { get; set; }
        public int Plan { get; set; }
        public int EstadoCivil { get; set; }
        public string NombrePadre { get; set; } = "";
        public string ApellidoPadre { get; set; } = "";
        public string NombreMadre { get; set; } = "";
        public string ApellidoMadre { get; set; } = "";
        public int ProvinciaId { get; set; }
        public int CiudadId { get; set; }
        public int DistritoId { get; set; }
        public int SectorId { get; set; }
        public string Calle { get; set; } = "";
        public string Referencia { get; set; } = "";
        public string Edificio { get; set; } = "";
        public string Telefono1 { get; set; } = "";
        public string Telefono2 { get; set; } = "";
        public string Piso { get; set; } = "";
        public string Apartamento { get; set; } = "";
    }
}
