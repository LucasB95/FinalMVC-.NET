using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Alojamiento
    {
        [Key]
        public int pk { get; set; }
        [Display(Name = "Codigo")]
        public int codigo { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }
        [Display(Name = "Barrio")]
        public string barrio { get; set; }
        [Display(Name = "Estrellas")]
        public int estrellas { get; set; }
        [Display(Name = "Cantidad Personas")]
        public int cantPersonas { get; set; }
        [Display(Name = "TV")]
        public bool tv { get; set; }
        [Display(Name = "Precio Dia")]
        public int precioDia { get; set; }
        [Display(Name = "Habitaciones")]
        public int habitaciones { get; set; }
        [Display(Name = "Baños")]
        public int baños { get; set; }
        [Display(Name = "Precio Por Persona")]
        public int precioPorPersona { get; set; }
        [Display(Name = "Tipo")]
        public string tipo { get; set; }

        public Alojamiento(int Codigo, string Tipo, string Ciudad, string Barrio, int Estrellas, int CantPersonas, bool Tv, int PrecioDIA, int PrecioPorPersona, int Habitaciones, int Baños, string Nombre)
        {
            codigo = Codigo;
            nombre = Nombre;
            barrio = Barrio;
            ciudad = Ciudad;
            estrellas = Estrellas;
            cantPersonas = CantPersonas;
            tv = Tv;
            precioDia = PrecioDIA;
            precioPorPersona = PrecioPorPersona;
            habitaciones = Habitaciones;
            baños = Baños;
            tipo = Tipo;
        }

        public Alojamiento()
        {

        }

    }
}
