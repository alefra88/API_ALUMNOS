namespace ALUMNOS_API_TRES.Models
{
    public class Alumnos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Curp { get; set; }
        public decimal? SueldoMensual { get; set; }
        public int? IdEstadoOrigen { get; set; }
        public int? IdEstatus { get; set; }

    }
}
