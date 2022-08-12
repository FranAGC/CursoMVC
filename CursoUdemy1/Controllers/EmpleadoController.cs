using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy1.Models;

namespace CursoUdemy1.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd = new BDPasajeEntities())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join TipoUsuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals TipoUsuario.IIDTIPOUSUARIO
                                 join TipoContrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals TipoContrato.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO == 1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     apPaterno = empleado.APPATERNO,
                                     nombreTipoUsurio = TipoUsuario.NOMBRE,
                                     nombreTipoContrato = TipoContrato.NOMBRE
                                 }).ToList();
            }
            return View(listaEmpleado);
        }


        public void listarComboSexo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from Sexo in bd.Sexo
                         where Sexo.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = Sexo.NOMBRE,
                             Value = Sexo.IIDSEXO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSexo = lista;
            }
        }


        public void listarTipoContrato()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoContrato
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOCONTRATO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoContrato = lista;
            }
        }

        public void listarTipoUsuario()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoUsuario
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOUSUARIO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoUsuario = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoUsuario();
            listarTipoContrato();
            listarComboSexo();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }



        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    listarCombos();
                    return View(oEmpleadoCLS);
                }
                else
                {
                    using (var bd = new BDPasajeEntities())
                    {
                        Empleado oEmpleado = new Empleado();
                        oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                        oEmpleado.APPATERNO = oEmpleadoCLS.apPaterno;
                        oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                        oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                        oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                        oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidtipoUsuario;
                        oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidtipoContrato;
                        oEmpleado.IIDSEXO = oEmpleadoCLS.iidSexo;
                        oEmpleado.BHABILITADO = 1;

                        bd.Empleado.Add(oEmpleado);
                        bd.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (IOException e)
            {
                // Extract some information from this exception, and then
                // throw it to the parent method.
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            listarCombos();
            EmpleadoCLS oEmpleadoCLS = new EmpleadoCLS();
            using (var bd = new BDPasajeEntities())
            {
                Empleado oEmpleado = bd.Empleado.Where(p => p.IIDEMPLEADO.Equals(id)).First();
                oEmpleadoCLS.iidEmpleado = oEmpleado.IIDEMPLEADO;
                oEmpleadoCLS.nombre = oEmpleado.NOMBRE;
                oEmpleadoCLS.apPaterno = oEmpleado.APMATERNO;
                oEmpleadoCLS.fechaContrato = (DateTime)oEmpleado.FECHACONTRATO;
                oEmpleadoCLS.sueldo = (decimal)oEmpleado.SUELDO;
                oEmpleadoCLS.iidtipoUsuario = (int)oEmpleado.IIDTIPOUSUARIO;
                oEmpleadoCLS.iidtipoContrato = (int)oEmpleado.IIDTIPOCONTRATO;
                oEmpleadoCLS.iidSexo = (int)oEmpleado.IIDSEXO;

            }


                return View(oEmpleadoCLS);
        }

    }
}