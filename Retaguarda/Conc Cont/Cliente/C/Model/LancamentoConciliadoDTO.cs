using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConciliacaoContabilClient.Model
{
    public class LancamentoConciliadoDTO
    {

        public LancamentoConciliadoDTO() { }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public System.Nullable<System.DateTime> DataMovimento { get; set; }
        public System.Nullable<System.DateTime> DataBalancete { get; set; }
        public string HistoricoExtrato { get; set; }
        public System.Nullable<decimal> ValorExtrato { get; set; }
        public string Classificacao { get; set; }
        public string HistoricoConta { get; set; }
        public string Tipo { get; set; }
        public System.Nullable<decimal> ValorConta { get; set; }

    }
}
