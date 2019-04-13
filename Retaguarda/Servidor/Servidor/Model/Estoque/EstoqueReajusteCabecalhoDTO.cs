using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EstoqueReajusteCabecalhoDTO {
        public EstoqueReajusteCabecalhoDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public System.Nullable<System.DateTime> DataReajuste { get; set; }
        public System.Nullable<decimal> Porcentagem { get; set; }
        public string TipoReajuste { get; set; }

        public IList<EstoqueReajusteDetalheDTO> ListaEstoqueReajusteDetalhe { get; set; }
    }
}
