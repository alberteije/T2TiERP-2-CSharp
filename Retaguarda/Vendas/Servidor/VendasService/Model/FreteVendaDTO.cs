using System;
using System.Text;
using System.Collections.Generic;


namespace VendasService.Model {
    
    public class FreteVendaDTO {
        public FreteVendaDTO() { }
        public int? Id { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public VendaCabecalhoDTO VendaCabecalho { get; set; }
        public System.Nullable<int> Conhecimento { get; set; }
        public string Responsavel { get; set; }
        public string Placa { get; set; }
        public string UfPlaca { get; set; }
        public System.Nullable<int> SeloFiscal { get; set; }
        public decimal? QuantidadeVolume { get; set; }
        public string MarcaVolume { get; set; }
        public string EspecieVolume { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
    }
}
