using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OrcamentoService.Model
{
    [DataContract]
    public class OrcamentoDetalheDTO
    {
        [DataMember]
        public int?  id { get; set; }
        [DataMember]
        public OrcamentoDTO orcamento { get; set; }
        [DataMember]
        public NaturezaFinanceiraDTO naturezaFinanceira { get; set; }
        [DataMember]
        public string periodo { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorOrcado { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorRealizado { get; set; }
        [DataMember]
        public System.Nullable<decimal> taxaVariacao { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorVariacao { get; set; }

    }
}