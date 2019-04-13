using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class InventarioContagemCabDTO {
        public InventarioContagemCabDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public System.Nullable<System.DateTime> DataContagem { get; set; }
        public string EstoqueAtualizado { get; set; }
        public string Tipo { get; set; }

        public IList<InventarioContagemDetDTO> listaContagemDetalhe { get; set; }
    }
}
