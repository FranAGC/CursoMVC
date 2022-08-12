using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoUdemy1.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iidcliente { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        public string apMaterno { get; set; }

        [Display(Name = "Email Cliente")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string email { get; set; }

        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string direccion { get; set; }

        [Display(Name = "Sexo Cliente")]
        [Required]
        public int iidsexo { get; set; }

        [Display(Name = "Telefono Fijo")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        public string telefonoFijo { get; set; }

        [Display(Name = "Telefono Celular")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        public string telefonoCelular { get; set; }

        public string bhabilitado { get; set; }

        public string btieneUsuario { get; set; }

        public string tipousUario { get; set; }
    }
}