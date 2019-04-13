using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetEspecificoCombustivelDTO {
        public NfeDetEspecificoCombustivelDTO() { }
        public int Id { get; set; }
        public int IdNfeDetalhe { get; set; }
        public System.Nullable<int> CodigoAnp { get; set; }
        public System.Nullable<decimal> PercentualGasNatural { get; set; }
        public string Codif { get; set; }
        public System.Nullable<decimal> QuantidadeTempAmbiente { get; set; }
        public string UfConsumo { get; set; }
        public System.Nullable<decimal> BaseCalculoCide { get; set; }
        public System.Nullable<decimal> AliquotaCide { get; set; }
        public System.Nullable<decimal> ValorCide { get; set; }
    }
}
