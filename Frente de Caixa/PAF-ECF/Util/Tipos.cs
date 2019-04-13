using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PafEcf.Util
{
    public static class Tipos
    {
        //0-aberto | 1-venda em andamento | 2-venda em recuperação ou importação de PV/DAV | 3-So Consulta | 4-Usuario cancelou a tela Movimento Aberto | 5-Informando dados de NF
        public enum StatusCaixa { scAberto, scFechado, scVendaEmAndamento, scVendaRecuperadaDavPreVenda, scSomenteConsulta, scUsuarioCancelouTelaMovimento, scInformandoDadosNF };
        // 0-não | 1-sim
        public enum SimNao { snNao, snSim };
    }
}
