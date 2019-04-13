using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class ParcelaRecebimentoDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public TipoRecebimentoDTO tipoRecebimento { get; set; }
        [DataMember]
        public int? idParcela { get; set; }
        [DataMember]
        public int? idContaCaixa { get; set; }
        [DataMember]
        public int? idChequeRecebido { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataRecebimento { get; set; }
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
        public System.Nullable<decimal> valorRecebido { get; set; }
        [DataMember]
        public String historico { get; set; }
    }
}