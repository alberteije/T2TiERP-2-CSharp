using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class CompraRequisicaoDTO {
        public CompraRequisicaoDTO() { }
        public int Id { get; set; }
        public CompraTipoRequisicaoDTO CompraTipoRequisicao { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataRequisicao { get; set; }
        public string Observacao { get; set; }
    }
}
