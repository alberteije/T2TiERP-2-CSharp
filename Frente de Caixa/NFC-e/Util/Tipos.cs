using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCe.Util
{
    public static class Tipos
    {
        //0-aberto | 1-venda em andamento | 2-fechado | 3-Importando Orçamentos | 4-Recuperando uma Venda
        public enum StatusCaixa { scAberto, scVendaEmAndamento, scFechado, scImportandoOrcamento, scRecuperandoVenda };
        // 0-não | 1-sim
        public enum SimNao { snNao, snSim };
    }
}
