using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Reserva
    {
        [Key]
        public int pk { get; set; }
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Fecha Desde")]
        public DateTime fdesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        public DateTime fhasta { get; set; }
        [Display(Name = "Propiedad")]
        public Alojamiento propiedad { get; set; }
        [Display(Name = "Persona")]
        public Usuario persona { get; set; }
        [Display(Name = "Alojamiento ID")]
        public int propiedadint { get; set; }
        [Display(Name = "Persona DNI")]
        public int personaint { get; set; }
        [Display(Name = "Precio")]
        public int precio { get; set; }


        public Reserva(int Id, DateTime Fdesde, DateTime Fhasta, int Precio, int Propiedadint, int Personaint)
        {
            id = Id;
            fdesde = Fdesde;
            fhasta = Fhasta;
            propiedadint = Propiedadint;
            personaint = Personaint;
            precio = Precio;
        }
        public Reserva()
        {

        }

      
    }
}
