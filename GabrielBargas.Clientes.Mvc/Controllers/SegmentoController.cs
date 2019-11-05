using GabrielBargas.Clientes.Database.Banco;
using GabrielBargas.Clientes.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBargas.Clientes.Mvc.Controllers
{
    public class SegmentoController : Controller
    {

        private readonly ISegmentoData ISegementoData;

        public SegmentoController(ISegmentoData _ISegmentoData)
        {
            this.ISegementoData = _ISegmentoData;
        }

        // GET: Segmento
        public ActionResult Index()
        {
            var segmentos = ISegementoData.ListarSegmentos();

            return View(segmentos);
        }

        // GET: Segmento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Segmento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Segmento/Create
        [HttpPost]
        public ActionResult Create(SEGMENTO segmento)
        {
            try
            {
                this.ISegementoData.CadastrarSegmento(segmento);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Segmento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Segmento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Segmento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Segmento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
