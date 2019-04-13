using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FluxoCaixaService.Model
{
    [DataContract]
    public class DocumentoOrigemDTO
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int idEmpresa { get; set; }
        [DataMember]
        public String descricao { get; set; }
    }
}