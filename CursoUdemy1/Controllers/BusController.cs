using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy1.Models;

namespace CursoUdemy1.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var bd = new BDPasajeEntities())
            {
                listaBus = (from bus in bd.Bus
                            join Sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals Sucursal.IIDSUCURSAL
                            join TipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals TipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO == 1
                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSucursal = Sucursal.NOMBRE,
                                nombreTipoBus = TipoBus.NOMBRE
                            }).ToList();
            }
            return View(listaBus);
        }

        public void listarTipoBus()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaTipoBus = lista;
            }
        }

        public void listarMarca()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaMarca = lista;
            }
        }


        public void listarModelo()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaModelo = lista;
            }
        }

        public void listarSucursal()
        {
            List<SelectListItem> lista;
            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaSucursal = lista;
            }
        }

        public void listarCombos()
        {
            listarTipoBus();
            listarMarca();
            listarModelo();
            listarSucursal();
        }

        
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }


        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCLS)
        {
            if(!ModelState.IsValid)
            {
                listarCombos();
                return View(oBusCLS);
            }

            using(var bd = new BDPasajeEntities())
            {
                Bus oBus = new Bus();
                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.IIDTIPOBUS = oBusCLS.iidTipoBus;
                oBus.PLACA = oBusCLS.placa;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROFILAS = oBusCLS.numeroFilas;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidMarca;
                oBus.BHABILITADO = 1;


                bd.Bus.Add(oBus);
                bd.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(BusCLS oBusCLS)
        {
            int idBus = oBusCLS.iidBus;
            if(!ModelState.IsValid)
            {
                return View(oBusCLS);
            }

            using(var bd=new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p => p.IIDBUS.Equals(idBus)).First();
                oBus.IIDSUCURSAL = oBusCLS.iidSucursal;
                oBus.IIDTIPOBUS = oBusCLS.iidTipoBus;
                oBus.FECHACOMPRA = oBusCLS.fechaCompra;
                oBus.IIDMODELO = oBusCLS.iidModelo;
                oBus.NUMEROCOLUMNAS = oBusCLS.numeroColumnas;
                oBus.DESCRIPCION = oBusCLS.descripcion;
                oBus.OBSERVACION = oBusCLS.observacion;
                oBus.IIDMARCA = oBusCLS.iidMarca;

                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            BusCLS oBusCLS = new BusCLS();
            listarCombos();

            using (var bd = new BDPasajeEntities())
            {
                Bus oBus = bd.Bus.Where(p=>p.IIDBUS.Equals(id)).First();
                oBusCLS.iidBus = (int)oBus.IIDBUS;
                oBusCLS.iidSucursal = (int)oBus.IIDSUCURSAL;
                oBusCLS.iidTipoBus = (int)oBus.IIDTIPOBUS;
                oBusCLS.placa = oBus.PLACA;
                oBusCLS.fechaCompra = (DateTime) oBus.FECHACOMPRA;
                oBusCLS.iidModelo = (int) oBus.IIDMODELO;
                oBusCLS.numeroColumnas = (int) oBus.NUMEROCOLUMNAS;
                oBusCLS.numeroFilas = (int) oBus.NUMEROFILAS;
                oBusCLS.descripcion = oBus.DESCRIPCION;
                oBusCLS.observacion = oBus.OBSERVACION;
                oBusCLS.iidMarca = (int) oBus.IIDMARCA;
            }

            return View(oBusCLS);
        }
    }
}