using GabrielBargas.Clientes.Database.Banco;
using GabrielBargas.Clientes.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBargas.Clientes.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteData IClienteData;
        private readonly ISegmentoData ISegmentoData;
        public ClienteController(IClienteData _IClienteData,ISegmentoData _ISegmentoData)
        {
            this.IClienteData = _IClienteData;
            this.ISegmentoData = _ISegmentoData;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = IClienteData.ListarClientes();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.Segmentos = new SelectList(ISegmentoData.ListarSegmentos(), "ID_SEGMENTO", "DESCRICAO");
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(CLIENTE cliente)
        {
            try
            {
                string idSegmento = Request.Form["Segmentos"].ToString();
                cliente.ID_SEGMENTO = Convert.ToInt32(idSegmento);
                IClienteData.CadastrarCliente(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
