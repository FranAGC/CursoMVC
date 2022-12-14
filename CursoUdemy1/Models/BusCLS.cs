using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoUdemy1.Models
{
    public class BusCLS
    {
        [Display(Name = "ID Buss")]
        public int iidBus { get; set; }
        
        [Display(Name = "Nombre Sucursal")]
        [Required]
        public int iidSucursal { get; set; }
        
        [Display(Name = "Tipo Bus")]
        [Required]
        public int iidTipoBus { get; set; }
       
        [Display(Name = "Fecha Compra")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime fechaCompra { get; set; }
        
        [Display(Name = "Placa")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string placa { get; set; }

        [Display(Name = "Nombre Modelo")]
        [Required]
        public int iidModelo { get; set; }
        
        [Display(Name = "Numero de Filas")]
        [Required]
        public int numeroFilas { get; set; }
        
        [Display(Name = "Numero de Columnas")]
        [Required]
        public int numeroColumnas { get; set; }
        
        public int bhabilitado { get; set; }
        
        [Display(Name = "Descripcion")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string descripcion { get; set; }
        
        [Display(Name = "Observacion")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string observacion { get; set; }
        
        [Display(Name = "Nombre Marca")]
        [Required]
        public int iidMarca { get; set; }


        //Propiedades adicionales
        [Display(Name = "Nombre Sucursal")]
        public string nombreSucursal { get; set; }
        
        [Display(Name = "Nombre Tipo Bus")]
        public string nombreTipoBus { get; set; }
        
        [Display(Name = "Nombre Modelo")]
        public string nombreModelo { get; set; }
        
        [Display(Name = "Nombre Marca")]
        public string nombreMarca { get; set; }
    }
}