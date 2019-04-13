using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class EstoqueContagemCabecalhoDTO {
        public EstoqueContagemCabecalhoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> DataContagem { get; set; }
        public string EstoqueAtualizado { get; set; }

        public IList<EstoqueContagemDetalheDTO> listaContagemDetalhe { get; set; }

    }
}
