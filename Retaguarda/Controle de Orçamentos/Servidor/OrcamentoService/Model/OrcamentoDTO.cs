using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OrcamentoService.Model
{
    [DataContract(IsReference = true)]
    public class OrcamentoDTO
    {
        [DataMember]
        public int? id { get; set; }
        [DataMember]
        public OrcamentoPeriodoDTO orcamentoPeriodo { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string descricao { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataInicial { get; set; }
        [DataMember]
        public int? numeroPeriodos { get; set; }
        [DataMember]
        public System.Nullable<System.DateTime> dataBase { get; set; }

        [DataMember]
        public IList<OrcamentoDetalheDTO> listaOrcamentoDetalhe { get; set; }
    }
}