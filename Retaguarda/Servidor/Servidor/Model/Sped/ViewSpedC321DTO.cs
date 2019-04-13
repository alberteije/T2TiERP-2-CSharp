using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC321DTO {
        public ViewSpedC321DTO() { }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string DescricaoUnidade { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public decimal SomaQuantidade { get; set; }
        public decimal SomaItem { get; set; }
        public decimal SomaDesconto { get; set; }
        public decimal SomaBaseIcms { get; set; }
        public decimal SomaIcms { get; set; }
        public decimal SomaPis { get; set; }
        public decimal SomaCofins { get; set; }
    }
}
