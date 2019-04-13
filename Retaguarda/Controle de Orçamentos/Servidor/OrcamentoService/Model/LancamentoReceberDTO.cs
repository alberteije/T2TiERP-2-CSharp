using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OrcamentoService.Model
{
    [DataContract]
    public class LancamentoReceberDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public DocumentoOrigemDTO documentoOrigem { get; set; }
        [DataMember]
        public int? idCliente { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorTotal { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorReceber { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataLancamento { get; set; }
        [DataMember]
        public String numeroDocumento { get; set; }
        [DataMember]
        public int? quantidadeParcela { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> primeiroVencimento { get; set; }

        public IList<FinLctoReceberNtFinanceiraDTO> ListaNaturezaFinanceira { get; set; }

    }
}