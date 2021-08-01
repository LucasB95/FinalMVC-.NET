using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class HomeUsuario : Controller
    {

        //private readonly FinalContextGlobal _context;

        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Busqueda()
        {
            return View();
        }
        //public async Task<IActionResult> Filtrado(int? estrellas)
        //{
        //    List<List<string>> aloj = new List<List<string>>();
        //    foreach (Alojamiento u in _context.Alojamiento)
        //    {
        //        if(u.estrellas == estrellas)
        //        {
        //            aloj.Add(new List<string>() {u.tipo,u.codigo.ToString(), u.nombre, u.ciudad, u.barrio, u.estrellas.ToString(), u.cantPersonas.ToString(),u.tv.ToString(),u.precioDia.ToString(),
        //                                    u.precioPorPersona.ToString(),u.habitaciones.ToString(),u.baños.ToString()});
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }


        //    return View(aloj);
        //}
    }
}
