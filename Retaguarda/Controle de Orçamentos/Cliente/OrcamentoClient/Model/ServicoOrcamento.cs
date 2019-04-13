using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using OrcamentoClient.OrcamentoReference;


namespace OrcamentoClient.Model
{
    public class ServicoOrcamento : ServiceClient
    {
        [SearchWindowDataSource(typeof(OrcamentoPeriodoDTO))]
        public new List<OrcamentoPeriodoDTO> selectPeriodo(OrcamentoPeriodoDTO Periodo)
        {
            return base.selectPeriodo(Periodo);
        }

    }



}
