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
    public class ClienteController : Controller
    {
        #region Parametros

        private readonly IClienteData IClienteData;
        private readonly ISegmentoData ISegmentoData;
        private readonly IEnderecoData IEnderecoData;
        private readonly IHistorico_RelacionamentoData IHistoricoRelacionamento;

        #endregion

        #region Construtor

        public ClienteController(IClienteData _IClienteData,ISegmentoData _ISegmentoData,IEnderecoData _IEnderecoData, IHistorico_RelacionamentoData _IHistoricoRelacionamento)
        {
            this.IClienteData = _IClienteData;
            this.ISegmentoData = _ISegmentoData;
            this.IEnderecoData = _IEnderecoData;
            this.IHistoricoRelacionamento = _IHistoricoRelacionamento;
        }

        #endregion

        #region Metodos Publicos
        
        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = IClienteData.ListarClientes();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {

            var clienteSelecionado = IClienteData.BuscarCliente(id);
            var segmento = ISegmentoData.BuscarSegmento((int)clienteSelecionado.ID_SEGMENTO);
            var histRelacionamento = IHistoricoRelacionamento.ListarHistoricoRelacionamentosCliente(clienteSelecionado.ID_CLIENTE);


            ViewBag.Endereco = IEnderecoData.ListarEnderecosCliente(clienteSelecionado.ID_CLIENTE);
            ViewBag.SegmentoDescricao = segmento.DESCRICAO;
            ViewBag.HistoricoRelacionamento = histRelacionamento.OrderByDescending(s => s.DATA_HISTORICO).ToList();

            return View(clienteSelecionado);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            var tipoClassificao = from TipoClassificacao e in Enum.GetValues(typeof(TipoClassificacao))
                                  select new
                                  {
                                      Id = (char)e,
                                      Descricao = e.ToString()
                                  };

            ViewBag.TipoClassificaçao = new SelectList(tipoClassificao, "ID", "Descricao");
            ViewBag.Segmentos = new SelectList(ISegmentoData.ListarSegmentos(), "ID_SEGMENTO", "DESCRICAO");

            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(CLIENTE cliente)
        {
            try
            {
                cliente = PuxarDadosDropdown(cliente);

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
            var clienteSelecionado = IClienteData.BuscarCliente(id);

            var tipoClassificao = from TipoClassificacao e in Enum.GetValues(typeof(TipoClassificacao))
                                  select new
                                  {
                                      Id = (char)e,
                                      Descricao = e.ToString()
                                  };

            ViewBag.TipoClassificaçao = new SelectList(tipoClassificao, "Id", "Descricao",clienteSelecionado.CLASSIFICACAO);
            ViewBag.Segmentos = new SelectList(ISegmentoData.ListarSegmentos(), "ID_SEGMENTO", "DESCRICAO",clienteSelecionado.ID_SEGMENTO);

            
            return View(clienteSelecionado);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(CLIENTE cliente,bool FlagInativo = false)
        {
            try
            {
                cliente = PuxarDadosDropdown(cliente);

                IClienteData.AtualizarCliente(cliente,FlagInativo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public void InativarCliente(int id)
        {
            try
            {
                bool flagInativo = true;

                IClienteData.InativarCliente(id,flagInativo);

                RedirectToAction("Index");
            }
            catch
            {
                RedirectToAction("Index");
            }
        }

        #endregion

        #region Metodos Privados

        private CLIENTE PuxarDadosDropdown(CLIENTE cliente)
        {
            string idSegmento = Request.Form["Segmentos"].ToString();
            string tipoClassificacao = Request.Form["TipoClassificaçao"].ToString();

            cliente.ID_SEGMENTO = Convert.ToInt32(idSegmento);
            cliente.CLASSIFICACAO = tipoClassificacao;

            return cliente;
        }
        
        #endregion
    }
}
