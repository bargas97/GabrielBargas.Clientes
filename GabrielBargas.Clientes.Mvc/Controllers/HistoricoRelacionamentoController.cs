using GabrielBargas.Clientes.Database.Banco;
using GabrielBargas.Clientes.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBargas.Clientes.Mvc.Controllers
{
    public class HistoricoRelacionamentoController : Controller
    {
        #region Parametros

        private readonly IClienteData IClienteData;
        private readonly IHistorico_RelacionamentoData IHistoricoRelacionamentoData;

        #endregion

        #region Construtor

        public HistoricoRelacionamentoController(IClienteData _IClienteData, IHistorico_RelacionamentoData _IHistoricoRelacionamentoData)
        {
            this.IClienteData = _IClienteData;
            this.IHistoricoRelacionamentoData = _IHistoricoRelacionamentoData;
        }

        #endregion
        // GET: HistoricoRelacionamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoricoRelacionamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistoricoRelacionamento/Create
        public ActionResult Create(int idCliente)
        {
            HISTORICO_RELACIONAMENTO histRelacionamento = new HISTORICO_RELACIONAMENTO();
            histRelacionamento.ID_CLIENTE = idCliente;

            return View(histRelacionamento); ;
        }

        // POST: HistoricoRelacionamento/Create
        [HttpPost]
        public ActionResult Create(HISTORICO_RELACIONAMENTO histRelacionamento)
        {
            try
            {
                histRelacionamento.DATA_HISTORICO = DateTime.Now;

                IHistoricoRelacionamentoData.CadastrarHistoricoRelacionamento(histRelacionamento);

                return RedirectToAction("Details", "Cliente", new { id = histRelacionamento.ID_CLIENTE });
            }
            catch
            {
                return RedirectToAction("Details", "Cliente", new { id = histRelacionamento.ID_CLIENTE });
            }
        }

        // GET: HistoricoRelacionamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistoricoRelacionamento/Edit/5
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

        // GET: HistoricoRelacionamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoricoRelacionamento/Delete/5
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
