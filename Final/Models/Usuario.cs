using Final.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Usuario
    {
        [Key] //para q tome lo q esta abajo como llave
        public int num_usr { get; set; }
        [Display(Name = "Documento")] // para q le cambie el nombre documento cuando lo muestre
        [Required]
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        [Required]
        //[ContrasenaValidate(ErrorMessage = "Contraseña no valida")]
        public string Password { get; set; }
        public bool esAdmin { get; set; }
        [Display(Name = "Bloqueado")]
        public bool bloqueado { get; set; }

        public Usuario(int DNI, string nom, string mail, string pass)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;
            bloqueado = false;
            esAdmin = false;

        }
        public Usuario(int DNI, string nom, string mail, string pass, bool esAdmin, bool bloq)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;
            this.esAdmin = esAdmin;
            bloqueado = bloq;

        }
        public Usuario()
        {

        }
        public bool getesAdmin()
        {
            return esAdmin;
        }

    }
}
