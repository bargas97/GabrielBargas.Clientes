using GabrielBargas.Clientes.Database.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Interfaces
{
    public interface IHistorico_RelacionamentoData
    {
        List<HISTORICO_RELACIONAMENTO> ListarHistoricoRelacionamentosCliente(int idCliente);

        Task CadastrarHistoricoRelacionamento(HISTORICO_RELACIONAMENTO historicoRelacionamento);

        Task<HISTORICO_RELACIONAMENTO> BuscarHistoricoRelaciomento(int id);
    }
}
