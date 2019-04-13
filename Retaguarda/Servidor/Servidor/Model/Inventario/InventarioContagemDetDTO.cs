using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class InventarioContagemDetDTO {
        public InventarioContagemDetDTO() { }
        public int Id { get; set; }
        public int IdInventarioContagemCab { get; set; }
        public ProdutoDTO Produto { get; set; }
        public System.Nullable<decimal> Contagem01 { get; set; }
        public System.Nullable<decimal> Contagem02 { get; set; }
        public System.Nullable<decimal> Contagem03 { get; set; }
        public string FechadoContagem { get; set; }
        public System.Nullable<decimal> QuantidadeSistema { get; set; }
        public System.Nullable<decimal> Acuracidade { get; set; }
        public System.Nullable<decimal> Divergencia { get; set; }
    }
}
