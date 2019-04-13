using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC425DTO {
        public ViewSpedC425DTO() { }
        public int Id { get; set; }
        public int IdEcfProduto { get; set; }
        public string DescricaoUnidade { get; set; }
        public string TotalizadorParcial { get; set; }
        public System.DateTime DataVenda { get; set; }
        public decimal SomaQuantidade { get; set; }
        public decimal SomaItem { get; set; }
        public decimal SomaPis { get; set; }
        public decimal SomaCofins { get; set; }
    }
}
