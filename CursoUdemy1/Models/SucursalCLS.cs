using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoUdemy1.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        [Required]
        public int iidsucursal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Direccion")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string email { get; set; }
        [Display(Name = "Fecha Apertura")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaApertura { get; set; }

        public int bhabilitado { get; set; }

    }
}