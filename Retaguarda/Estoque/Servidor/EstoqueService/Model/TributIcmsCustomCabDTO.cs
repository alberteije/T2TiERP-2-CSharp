using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class TributIcmsCustomCabDTO {
        public TributIcmsCustomCabDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string OrigemMercadoria { get; set; }
    }
}
