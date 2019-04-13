using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetalheImpostoCofinsDTO {
        public NfeDetalheImpostoCofinsDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public string CstCofins { get; set; }
        public System.Nullable<decimal> QuantidadeVendida { get; set; }
        public System.Nullable<decimal> BaseCalculoCofins { get; set; }
        public System.Nullable<decimal> AliquotaCofinsPercentual { get; set; }
        public System.Nullable<decimal> AliquotaCofinsReais { get; set; }
        public System.Nullable<decimal> ValorCofins { get; set; }
    }
}
