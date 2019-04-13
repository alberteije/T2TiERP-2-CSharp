using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchWindow.Attributes;
using CaixaBancosClient.CaixaBancosService;


namespace CaixaBancosClient.Model
{
    public class ServicoCaixaBancos : CaixaBancosServiceClient
    {
        [SearchWindowDataSource(typeof(ContabilContaDTO))]
        public new List<ContabilContaDTO> selectContabilConta(ContabilContaDTO ContabilConta)
        {
            return base.selectContabilConta(ContabilConta);
        }

        [SearchWindowDataSource(typeof(ContaCaixaDTO))]
        public new List<ContaCaixaDTO> selectContaCaixa(ContaCaixaDTO ContaCaixa)
        {
            return base.selectContaCaixa(ContaCaixa);
        }

    }



}
