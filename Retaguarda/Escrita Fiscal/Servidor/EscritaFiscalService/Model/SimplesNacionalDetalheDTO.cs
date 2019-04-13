using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class SimplesNacionalDetalheDTO {
        public SimplesNacionalDetalheDTO() { }
        public int? Id { get; set; }
        public int? IdSimplesNacionalCabecalho { get; set; }
        public System.Nullable<int> Faixa { get; set; }
        public System.Nullable<decimal> ValorInicial { get; set; }
        public System.Nullable<decimal> ValorFinal { get; set; }
        public System.Nullable<decimal> Aliquota { get; set; }
        public System.Nullable<decimal> Irpj { get; set; }
        public System.Nullable<decimal> Csll { get; set; }
        public System.Nullable<decimal> Cofins { get; set; }
        public System.Nullable<decimal> PisPasep { get; set; }
        public System.Nullable<decimal> Cpp { get; set; }
        public System.Nullable<decimal> Icms { get; set; }
        public System.Nullable<decimal> Ipi { get; set; }
        public System.Nullable<decimal> Iss { get; set; }
    }
}
