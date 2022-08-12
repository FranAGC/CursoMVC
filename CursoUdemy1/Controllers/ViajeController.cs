using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoUdemy1.Models;

namespace CursoUdemy1.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> listaViaje = null;
            using (var bd = new BDPasajeEntities())
            {
                listaViaje = (from Viaje in bd.Viaje
                              join Lugar in bd.Lugar
                              on Viaje.IIDLUGARORIGEN equals Lugar.IIDLUGAR
                              join lugarDestino in bd.Lugar
                              on Viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                              join Bus in bd.Bus
                              on Viaje.IIDBUS equals Bus.IIDBUS
                              select new ViajeCLS
                              {
                                  iidViaje = Viaje.IIDVIAJE,
                                  nombreBus = Bus.PLACA,
                                  nombreLugarOrigen = Lugar.NOMBRE,
                                  nombreLugarDestino = lugarDestino.NOMBRE
                              }).ToList();
            }
            return View(listaViaje);
        }
    }
}