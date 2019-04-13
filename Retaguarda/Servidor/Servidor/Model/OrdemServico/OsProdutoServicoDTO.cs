using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class OsProdutoServicoDTO {
        public OsProdutoServicoDTO() { }
        public int Id { get; set; }

        public OsAberturaDTO OsAbertura { get; set; }
        public ProdutoDTO Produto { get; set; }

        public System.Nullable<int> Tipo { get; set; }
        public string Complemento { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
        public System.Nullable<decimal> ValorUnitario { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> TaxaDesconto { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
    }
}
