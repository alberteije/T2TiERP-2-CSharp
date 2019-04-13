using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class VendaFreteDTO {
        public VendaFreteDTO() { }
        public int Id { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public VendaCabecalhoDTO VendaCabecalho { get; set; }
        public System.Nullable<int> Conhecimento { get; set; }
        public string Responsavel { get; set; }
        public string Placa { get; set; }
        public string UfPlaca { get; set; }
        public System.Nullable<int> SeloFiscal { get; set; }
        public System.Nullable<decimal> QuantidadeVolume { get; set; }
        public string MarcaVolume { get; set; }
        public string EspecieVolume { get; set; }
        public System.Nullable<decimal> PesoBruto { get; set; }
        public System.Nullable<decimal> PesoLiquido { get; set; }
    }
}
