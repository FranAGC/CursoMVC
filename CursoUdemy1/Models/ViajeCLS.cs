using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoUdemy1.Models
{
    public class ViajeCLS
    {
        [Display(Name = "Id Viaje")]
        [Required]
        public int iidViaje { get; set; }
        [Display(Name = "Lugar Origen")]
        [Required]
        public int iidLugarOrigen { get; set; }
        [Display(Name = "Lugar Destino")]
        [Required]
        public int iidLugarDestino { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public double precio { get; set; }
        [Display(Name = "Fecha Viaje")]
        [Required]
        public DateTime fechaViaje { get; set; }
        [Display(Name = "Bus")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public int iidBus { get; set; }
        [Display(Name = "Numero Asientos Disponibles")]
        [Required]
        public int numero { get; set; }


        //Propiedades Adiciones
        [Display(Name = "Lugar Origen")]
        public string nombreLugarOrigen { get; set; }
        [Display(Name = "Lugar Destino")]
        public string nombreLugarDestino { get; set; }
        [Display(Name = "Nombre Bus")]
        public string nombreBus { get; set; }
    }
}