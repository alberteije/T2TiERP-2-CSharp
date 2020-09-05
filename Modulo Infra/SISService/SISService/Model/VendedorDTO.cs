using System;
using System.Text;
using System.Collections.Generic;


namespace SISService.Model {
    
    public class VendedorDTO {
        public VendedorDTO() { }
        public int Id { get; set; }
        public SituacaoVendedorDTO SituacaoVendedor { get; set; }
        public TipoPagamentoDTO TipoPagamento { get; set; }
        public LocalVendaDTO LocalVenda { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}
