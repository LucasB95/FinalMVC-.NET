using Final.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class BusquedaControllercs : Controller
    {

        //private readonly FinalContextGlobal _context;

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index(int? estrellas)
        //{

        //    if (estrellas == 0)
        //    {
        //        return NotFound();
        //    }

        //    var alojamiento = await _context.Alojamiento.FirstOrDefaultAsync(m => m.estrellas == estrellas);
        //    if (alojamiento == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(alojamiento);

        //}
    }
}
