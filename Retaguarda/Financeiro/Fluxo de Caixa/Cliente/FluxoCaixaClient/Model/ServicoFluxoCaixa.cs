using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using FluxoCaixaClient.FluxoCaixaReference;


namespace FluxoCaixaClient.Model
{
    public class ServicoFluxoCaixa : ServiceClient
    {
        [SearchWindowDataSource(typeof(ContaCaixaDTO))]
        public new List<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO ContaCaixa)
        {
            return base.selectContaCaixa(ContaCaixa);
        }

    }



}
