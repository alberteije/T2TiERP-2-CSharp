using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class RequisicaoInternaCabecalhoDTO {
        public RequisicaoInternaCabecalhoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataRequisicao { get; set; }
        public string Situacao { get; set; }


        public IList<RequisicaoInternaDetalheDTO> ListaRequisicaoInternaDetalhe { get; set; }
    }
}
