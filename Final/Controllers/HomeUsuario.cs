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


      
    }
}
