using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2PracticaMitologia.Models.Entities;
using U2PracticaMitologia.Models.ViewModels;

namespace U2PracticaMitologia.Controllers
{
    public class HomeController : Controller
    {
        MitologiaMexicanaContext context = new();

        public IActionResult Index()
        {
            IndexViewModel vm = new();

            //vm = context.Civilizaciones.OrderBy(x=>EF.Functions.Random())
            //vm = context.Civilizaciones.OrderBy(x => EF.Functions.Random()).Take(3)
            //    .Select(c => new CivilizacionesAleatoriasModel
            //    {
            //        Nombre = c.Nombre,
            //        Descripcion = c.Descripcion,
            //        IdCivilizacion = c.IdCivilizacion
            //    });

            vm.CivilizacionesAleatorias = context.Civilizaciones
                .OrderBy(x => EF.Functions
                .Random())
                .Take(3)
                .Select(c => new CivilizacionesAleatoriasModel
               {
                   Nombre = c.Nombre,
                   Descripcion = c.Descripcion
               });

            return View(vm);
        }

        public IActionResult Civilizaciones()
        {
            CivilizacionesViewModel vm = new();
            vm.CivilizacionesTarjetas = context.Civilizaciones
                .OrderBy(x => x.Nombre)
                .Select(c => new CivilizacionesTarjetasModel
                {
                    Nombre = c.Nombre,
                    Periodo = $"{c.PeriodoInicio} - {c.PeriodoFin}",
                    Region = c.Region,
                    Capital = c.Capital,
                    Lengua = c.Lengua,
                    Descripcion = c.Descripcion,
                    Imagen = c.Nombre
                    .ToLower()
                });
            return View(vm);
        }

        public IActionResult Dioses(string id)
        {
            MitologiaMexicanaContext context = new();
            DiosesViewModel vm = new();

            if (id != null)
            {
                vm.NombreSeleccionado = id;
            }
            else
            {
                vm.NombreSeleccionado = context.Civilizaciones
                    .Select(x => x.Nombre)
                    .First();
            }
            vm.CivilizacionesMostrar = context.Civilizaciones
                .Select(x => x.Nombre);

            vm.ListaDioses = context.CivilizacionDios
                .Include(x => x.IdCivilizacionNavigation)
                .Include(x => x.IdDiosNavigation)
                .Where(c => c.IdCivilizacionNavigation.Nombre == vm.NombreSeleccionado)
                .Select(c => new ListaDiosesModel
                {
                    Id = c.Id,
                    Nombre = c.IdDiosNavigation.NombreGeneral,
                    Civilizacion = c.IdCivilizacionNavigation.Nombre,
                    Genero = c.IdDiosNavigation.Genero,
                    Dominio = c.IdDiosNavigation.Dominio,
                    NombreLocal = c.NombreLocal,
                    Descripcion = c.IdDiosNavigation.Descripcion
                });
            return View(vm);
        }
    }
}
