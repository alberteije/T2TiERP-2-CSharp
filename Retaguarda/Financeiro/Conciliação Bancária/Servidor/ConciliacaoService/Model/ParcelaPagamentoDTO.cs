using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class ParcelaPagamentoDTO
    {
        [DataMember]
        public int? id { get; set; }
        /**
        [DataMember]
        public int? idTipoPagamento { get; set; }
         **/
        [DataMember]
        public TipoPagamentoDTO tipoPagamento { get; set; }
        [DataMember]
        public int? idChequeEmitido { get; set; }
        [DataMember]
        public int? idParcela { get; set; }
        [DataMember]
        public int? idContaCaixa { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataPagamento { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorPago { get; set; }
        [DataMember]
        public System.Nullable<decimal> taxaJuro { get; set; }
        [DataMember]
        public System.Nullable<decimal> taxaMulta { get; set; }
        [DataMember]
        public System.Nullable<decimal> taxaDesconto { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorJuro { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorMulta { get; set; }
        [DataMember]
        public System.Nullable<decimal> valorDesconto { get; set; }
        [DataMember]
        public String historico { get; set; }
    }
}