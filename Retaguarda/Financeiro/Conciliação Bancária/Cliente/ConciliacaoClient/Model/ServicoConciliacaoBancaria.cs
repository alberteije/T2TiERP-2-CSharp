using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using ConciliacaoClient.ConciliacaoService;


namespace ConciliacaoClient.Model
{
    public class ServicoConciliacaoBancaria : ConciliacaoServiceClient
    {
        [SearchWindowDataSource(typeof(ContaCaixaDTO))]
        public new List<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO ContaCaixa)
        {
            return base.selectContaCaixa(ContaCaixa);
        }

    }



}
