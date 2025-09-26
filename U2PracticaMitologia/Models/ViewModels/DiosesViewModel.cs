namespace U2PracticaMitologia.Models.ViewModels
{
    public class DiosesViewModel
    {
        //public string Nombre { get; set; } = null!;
        public string? NombreSeleccionado { get; set; } 
        public IEnumerable<string> CivilizacionesMostrar { get; set; } = null!;

        public IEnumerable<ListaDiosesModel> ListaDioses { get; set; } = null!;

    }
    public class ListaDiosesModel
    {
        public int Id { get; set; }
        public string Nombre { set; get; } = null!;

        public string Civilizacion { get; set; } = null!;

        public string NombreLocal { get; set; } = null!;

        public string? Genero { get; set; }

        public string? Dominio { get; set; }

        public string? Descripcion { get; set; }
    }
}
