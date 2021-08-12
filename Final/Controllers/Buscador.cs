using Final.Data;
using Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class Buscador : Controller
    {
        private readonly int _RegistrosPorPagina = 10;

        private FinalContextGlobal _DbContext;
        private List<Alojamiento> _Customers;
        private Paginacion<Alojamiento> _PaginadorCustomers;
        public DateTime Fdesde;
        public DateTime Fhasta;
            

        // GET: Customers
        public ActionResult Index(string buscar, int cantidad, DateTime Fdesde, DateTime Fhasta,int estrellas,int precio, int pagina = 1)
        {
           

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            this.Fdesde = Fdesde;
            this.Fhasta = Fhasta;



            // FILTRO DE BÚSQUEDA
            using (_DbContext = new FinalContextGlobal())
            {
                // Recuperamos el 'DbSet' completo
                _Customers = _DbContext.Alojamiento.ToList();

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar) || cantidad != 0)
                {
                    foreach (var item in _Customers)
                    {
                        _Customers = _Customers.Where(x =>  (x.ciudad.Contains(buscar) || x.barrio.Contains(buscar)) || x.cantPersonas >= cantidad)
                                                      .ToList();
                    }
                }
            }

            // SISTEMA DE PAGINACIÓN
            using (_DbContext = new FinalContextGlobal())
            {
                // Número total de registros de la tabla Customers
                _TotalRegistros = _Customers.Count();
                // Obtenemos la 'página de registros' de la tabla Customers
                _Customers = _Customers.OrderBy(x => x.ciudad)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
                // Número total de páginas de la tabla Customers
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorCustomers = new Paginacion<Alojamiento>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaActual = buscar,
                    Resultado = _Customers
                };
            }

            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorCustomers);

        }
        public ActionResult Cabaña(string buscar, int pagina = 1)
        {
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            // FILTRO DE BÚSQUEDA
            using (_DbContext = new FinalContextGlobal())
            {
                // Recuperamos el 'DbSet' completo
                _Customers = _DbContext.Alojamiento.ToList();

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar))
                {
                    foreach (var item in buscar.Split(new char[] { ' ' },
                             StringSplitOptions.RemoveEmptyEntries))
                    {
                        _Customers = _Customers.Where(x =>  (x.ciudad.Contains(item) || x.barrio.Contains(item) && x.tipo.Contains("Cabaña") ))
                                                      .ToList();
                    }
                }
            }

            // SISTEMA DE PAGINACIÓN
            using (_DbContext = new FinalContextGlobal())
            {
                // Número total de registros de la tabla Customers
                _TotalRegistros = _Customers.Count();
                // Obtenemos la 'página de registros' de la tabla Customers
                _Customers = _Customers.OrderBy(x => x.ciudad)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
                // Número total de páginas de la tabla Customers
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorCustomers = new Paginacion<Alojamiento>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaActual = buscar,
                    Resultado = _Customers
                };
            }

            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorCustomers);

        }

        public ActionResult Hotel(string buscar,int pagina = 1)
        {
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;

            // FILTRO DE BÚSQUEDA
            using (_DbContext = new FinalContextGlobal())
            {
                // Recuperamos el 'DbSet' completo
                _Customers = _DbContext.Alojamiento.ToList();

                // Filtramos el resultado por el 'texto de búqueda'
                if (!string.IsNullOrEmpty(buscar))
                {
                    foreach (var item in buscar.Split(new char[] { ' ' },
                             StringSplitOptions.RemoveEmptyEntries))
                    {
                        _Customers = _Customers.Where(x => x.ciudad.Contains(item) || x.barrio.Contains(item) || x.tipo.Contains(item))
                                                      .ToList();
                    }
                }
            }

            // SISTEMA DE PAGINACIÓN
            using (_DbContext = new FinalContextGlobal())
            {
                // Número total de registros de la tabla Customers
                _TotalRegistros = _Customers.Count();
                // Obtenemos la 'página de registros' de la tabla Customers
                _Customers = _Customers.OrderBy(x => x.ciudad)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
                // Número total de páginas de la tabla Customers
                _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorCustomers = new Paginacion<Alojamiento>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    BusquedaActual = buscar,
                    Resultado = _Customers
                };
            }

            // Enviamos a la Vista la 'Clase de paginación'
            return View(_PaginadorCustomers);
        }


    }
}
