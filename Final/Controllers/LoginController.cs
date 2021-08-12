using Final.Models;
using Final.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Controllers
{
    public class LoginController : Controller
    {

        private DbSet<Usuario> misUsuarioos;
        private FinalContextGlobal contextGlobal;
        private readonly FinalContextGlobal _contextReser;

        public const string SessionUser = "_User";
        public IConfiguration Configuration { get; }
        public LoginController(IConfiguration configuration, FinalContextGlobal context)
        {
            Configuration = configuration;
            _contextReser = context;
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contextGlobal = new FinalContextGlobal();
                //cargo los usuarios
                contextGlobal.Usuario.Load();
                misUsuarioos = contextGlobal.Usuario;
         
            }
            catch (Exception)
            {

            }
        }


        public ActionResult Login()
        {
            return View(new Usuario());
        }

        [HttpPost]

        public ActionResult Login(Usuario model)
        {
            string ConnectionString = Properties.Resources.ConnectionString;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var list_users = new List<Usuario>();
                if(model.DNI == 0 || model.DNI.Equals("") || model.Password == null || model.Password.Equals(""))
                {
                    ModelState.AddModelError("", "Ingresar los datos solicitados");
                }
                else
                {
                    SqlCommand com = new SqlCommand("GET_SEG_USUARIO", connection);
                    connection.Open();
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@DNI", model.DNI);
                    com.Parameters.AddWithValue("Password", model.Password);
                    SqlDataReader dr = com.ExecuteReader();

                    while(dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.DNI = Convert.ToInt32(dr["DNI"]);
                        usuario.Password = Convert.ToString(dr["Password"]);

                        list_users.Add(usuario);
                    }
                    if(list_users.Any(p => p.DNI == model.DNI && p.Password == model.Password))
                    {
                       foreach(Usuario usu in contextGlobal.Usuario)
                        {
                            if (usu.DNI == model.DNI)
                            {
                                if (usu.getesAdmin())
                                {

                                //ModelState.AddModelError("", "Datos ingresado no válido.");

                                //ViewBag.Mensaje = list_users[i].getesAdmin();
                                                               

                                HttpContext.Session.SetInt32(SessionUser, model.DNI);

                               

                                return RedirectToAction("Index", "Home");


                                }
                            }
                            else
                            {
                                //ViewBag.Mensaje = a.getesAdmin();
                                //ModelState.AddModelError("", "Datos ingresado no válido.");
                                HttpContext.Session.SetInt32(SessionUser, model.DNI);

                                return RedirectToAction("Index", "HomeUsuario");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Datos ingresado no válido.");
                    }
                }
                connection.Close();
                return View(model);
            }
        }
        [HttpPost]
       public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }


        // GET: Reservas
        public async Task<IActionResult> Reserva()
        {
            return View(await _contextReser.Reserva.ToListAsync());
        }


    }
}
