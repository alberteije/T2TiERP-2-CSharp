using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TesourariaService.Model
{
    [DataContract]
    public class FechamentoCaixaBancoDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int? idContaCaixa { get; set; }
        [DataMember]
        public DateTime? dataFechamento { get; set; }
        [DataMember]
        public int? mes { get; set; }
        [DataMember]
        public int? ano { get; set; }
        [DataMember]
        public decimal? saldoAnterior { get; set; }
        [DataMember]
        public decimal? recebimentos { get; set; }
        [DataMember]
        public decimal? pagamentos { get; set; }
        [DataMember]
        public decimal? saldoConta { get; set; }
        [DataMember]
        public decimal? chequeNaoCompensado { get; set; }
        [DataMember]
        public decimal? saldoDisponivel { get; set; }
    }
}