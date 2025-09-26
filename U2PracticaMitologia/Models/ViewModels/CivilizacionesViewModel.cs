namespace U2PracticaMitologia.Models.ViewModels
{
    public class CivilizacionesViewModel
    {
        public IEnumerable<CivilizacionesTarjetasModel> CivilizacionesTarjetas { get; set; } = null!;
    }
    public class CivilizacionesTarjetasModel
    {
        public string Nombre { get; set; } = null!;

        public string Periodo { get; set; } = null!;

        public string? Region { get; set; }

        public string? Capital { get; set; }

        public string? Lengua { get; set; }

        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
    }
}
