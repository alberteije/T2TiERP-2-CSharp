using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC300DTO {
        public ViewSpedC300DTO() { }
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Subserie { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public decimal SomaTotalNf { get; set; }
        public decimal SomaPis { get; set; }
        public decimal SomaCofins { get; set; }
    }
}
