using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ConciliacaoService.Model
{
    [DataContract]
    public class TipoPagamentoDTO
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int idEmpresa { get; set; }
        [DataMember]
        public String descricao { get; set; }
        [DataMember]
        public string tipo { get; set; }

    }
}