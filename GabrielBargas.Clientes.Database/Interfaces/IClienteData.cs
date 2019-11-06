using GabrielBargas.Clientes.Database.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Interfaces
{
    public interface IClienteData
    {
        IEnumerable<CLIENTE> ListarClientes();

        Task CadastrarCliente(CLIENTE cliente);

        Task AtualizarCliente(CLIENTE cliente,bool FlagInativo);

        CLIENTE BuscarCliente(int id);
    }
}
