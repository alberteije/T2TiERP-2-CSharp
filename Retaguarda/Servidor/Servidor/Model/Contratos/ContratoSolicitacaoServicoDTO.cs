using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContratoSolicitacaoServicoDTO {
        public ContratoSolicitacaoServicoDTO() { }
        public int Id { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public ClienteDTO Cliente { get; set; }
        public SetorDTO Setor { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public ContratoTipoServicoDTO ContratoTipoServico { get; set; }
        public System.Nullable<System.DateTime> DataSolicitacao { get; set; }
        public System.Nullable<System.DateTime> DataDesejadaInicio { get; set; }
        public string Urgente { get; set; }
        public string StatusSolicitacao { get; set; }
        public string Descricao { get; set; }
    }
}
