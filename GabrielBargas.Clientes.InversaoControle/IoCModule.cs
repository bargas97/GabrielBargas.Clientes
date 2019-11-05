using GabrielBargas.Clientes.Database.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using GabrielBargas.Clientes.Database.Data;

namespace GabrielBargas.Clientes.InversaoControle
{
    public class IoCModule:NinjectModule
    {
        #region Metodos Publicos

        public override void Load()
        {
            CarregarData();
        }

        #endregion

        #region metodos Privados

        private void CarregarData()
        {
            Bind<IClienteData>().To<ClienteData>();
            Bind<IEnderecoData>().To<EnderecoData>();
            Bind<ISegmentoData>().To<SegmentoData>();
            Bind<IHistorico_RelacionamentoData>().To<Historico_RelacionamentoData>();
        }
        
        #endregion
    }
}
