using GabrielBargas.Clientes.Business.Enums;
using GabrielBargas.Clientes.Database.Banco;
using GabrielBargas.Clientes.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GabrielBargas.Clientes.Mvc.Controllers
{
    public class EnderecoController : Controller
    {
        #region Parametros

        private readonly IClienteData IClienteData;
        private readonly ISegmentoData ISegmentoData;
        private readonly IEnderecoData IEnderecoData;

        #endregion

        #region Construtor

        public EnderecoController(IClienteData _IClienteData, ISegmentoData _ISegmentoData, IEnderecoData _IEnderecoData)
        {
            this.IClienteData = _IClienteData;
            this.ISegmentoData = _ISegmentoData;
            this.IEnderecoData = _IEnderecoData;
        }

        #endregion

        #region Metodos publicos
        // GET: Endereco
        public ActionResult Index()
        {
            return View();
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Endereco/Create
        public ActionResult Create(int idCliente)
        {
            var tipoEndereco= from TipoEndereco e in Enum.GetValues(typeof(TipoEndereco))
                                  select new
                                  {
                                      Id = (char)e,
                                      Descricao = e.ToString()
                                  };
            ViewBag.TipoEndereco = new SelectList(tipoEndereco, "Id", "Descricao");

            ENDERECO endereco = new ENDERECO();
            endereco.ID_CLIENTE = idCliente;

            return View(endereco);
        }

        // POST: Endereco/Create
        [HttpPost]
        public ActionResult Create(ENDERECO endereco)
        {
            try
            {
                string tipoEndereco = Request.Form["tipoEndereco"].ToString();
                endereco.TIPO_ENDERECO = tipoEndereco;
                IEnderecoData.CadastrarEndereco(endereco);

                return RedirectToAction("Details", "Cliente", new { id = endereco.ID_CLIENTE });
            }
            catch
            {
                return RedirectToAction("Details", "Cliente", new { id = Convert.ToInt32(endereco.ID_CLIENTE) });
            }
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(int id)
        {
            var tipoEndereco = from TipoEndereco e in Enum.GetValues(typeof(TipoEndereco))
                               select new
                               {
                                   Id = (char)e,
                                   Descricao = e.ToString()
                               };
            

            var endereco = IEnderecoData.BuscarEndereco(id);

            ViewBag.TipoEndereco = new SelectList(tipoEndereco, "Id", "Descricao",endereco.TIPO_ENDERECO);

            return View(endereco);
        }

        // POST: Endereco/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ENDERECO endereco)
        {
            try
            {
                string tipoEndereco = Request.Form["tipoEndereco"].ToString();
                endereco.TIPO_ENDERECO = tipoEndereco;

                IEnderecoData.AlterarEndereco(endereco);

                return RedirectToAction("Details", "Cliente", new { id = endereco.ID_CLIENTE });

            }
            catch
            {
                return View("Details", "Cliente", new { id = Convert.ToInt32(endereco.ID_CLIENTE) });
            }
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Endereco/Delete/5
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
        #endregion
    }
}
