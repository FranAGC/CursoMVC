using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoUdemy1.Models
{
    public class EmpleadoCLS
    {

        [Display(Name = "Id Empleado")]
        public int iidEmpleado { get; set; }
        
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string nombre { get; set; }
        
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string apPaterno { get; set; }
        
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string apMaterno { get; set; }
        
        [Display(Name = "Fecha Contrato")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaContrato { get; set; }
        
        [Display(Name = "Sueldo")]
        [Required]
        [Range(0, 1000000, ErrorMessage = "Fuera de rango")]
        public decimal sueldo { get; set; }

        [Display(Name = "Tipo Usuraio")]
        [Required]
        public int iidtipoUsuario { get; set; }
        
        [Display(Name = "Tipo Contrato")]
        [Required]
        public int iidtipoContrato { get; set; }
        
        [Display(Name = "Id Sexo")]
        [Required]
        public int iidSexo { get; set; }
        
        [Required]
        public int bhabilitado { get; set; }





        //Propiedades Adicionalees
        [Display(Name = "Tipo Contrato")]
        public string nombreTipoContrato { get; set; }
        [Display(Name = "Tipo Usuraio")]
        public string nombreTipoUsurio { get; set; }



    }
}