using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OrcamentoService.Model
{
    [DataContract(IsReference = true)]
    public class OrcamentoPeriodoDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public int? idEmpresa { get; set; }
        [DataMember]
        public string periodo { get; set; }
        [DataMember]
        public string nome { get; set; }

    }
}