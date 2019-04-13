using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OrcamentoService.Model
{
    [DataContract(IsReference = true)]
    public class NaturezaFinanceiraDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int idPlanoNaturezaFinanceira { get; set; }
        [DataMember]
        public string descricao { get; set; }
        [DataMember]
        public string tipo { get; set; }
        [DataMember]
        public string classificacao { get; set; }
    }
}