using GabrielBargas.Clientes.Database.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielBargas.Clientes.Database.Interfaces
{
    public interface ISegmentoData
    {
        IEnumerable<SEGMENTO> ListarSegmentos();

        Task CadastrarSegmento(SEGMENTO SEGMENTO);

        SEGMENTO BuscarSegmento(int id);
    }
}
