using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedC370DTO {
        public ViewSpedC370DTO() { }
        public int Id { get; set; }
        public int IdNfCabecalho { get; set; }
        public System.DateTime DataEmissao { get; set; }
        public int IdProduto { get; set; }
        public int Item { get; set; }
        public int IdUnidadeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public string Cst { get; set; }
        public decimal Desconto { get; set; }
    }
}
