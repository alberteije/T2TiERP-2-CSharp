using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class ContaCaixaDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int? idEmpresa { get; set; }
        [DataMember]
        public int? idAgenciaBanco { get; set; }
        [DataMember]
        public string codigo { get; set; }
        [DataMember]
        public string digito { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string descricao { get; set; }
        [DataMember]
        public char? tipo { get; set; }
    }
}