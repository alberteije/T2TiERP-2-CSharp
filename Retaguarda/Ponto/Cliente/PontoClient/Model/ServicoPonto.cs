using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PontoClient.ServicoPontoReference;
using SearchWindow.Attributes;
using SearchWindow;

namespace PontoClient.Model
{
    public class ServicoPonto : ServicoPontoClient
    {
        [SearchWindowDataSource(typeof(ColaboradorDTO), new string[] { "Id", "Pessoa.Nome" }, new string[] { "Id", "Nome" })]
        public new List<ColaboradorDTO> selectColaborador(ColaboradorDTO dtoPesquisa)
        {
            return base.selectColaborador(dtoPesquisa);
        }
    }
}
