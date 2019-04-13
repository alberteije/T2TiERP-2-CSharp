using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class ExtratoContaBancoDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int? idContaCaixa { get; set; }
        [DataMember]
        public string mes { get; set; }
        [DataMember]
        public string ano { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataMovimento { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataBalancete { get; set; }
        [DataMember]
        public string historico { get; set; }
        [DataMember]
        public string documento { get; set; }
        [DataMember]
        public System.Nullable<decimal> valor { get; set; }
        [DataMember]
        public string conciliado { get; set; }
        [DataMember]
        public string observacao { get; set; }
    }
}