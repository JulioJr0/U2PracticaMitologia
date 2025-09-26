namespace U2PracticaMitologia.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CivilizacionesAleatoriasModel> CivilizacionesAleatorias { get; set; } = null!;
    }
    public class CivilizacionesAleatoriasModel
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }
    }
}
