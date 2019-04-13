using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC390DTO {
        public ViewSpedC390DTO() { }
        public int Id { get; set; }
        public string Cst { get; set; }
        public int Cfop { get; set; }
        public decimal TaxaIcms { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public decimal SomaItem { get; set; }
        public decimal SomaBaseIcms { get; set; }
        public decimal SomaIcms { get; set; }
        public decimal SomaIcmsOutras { get; set; }
    }
}
