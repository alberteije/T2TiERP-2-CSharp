using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfTipoPagamentoDTO {
        public EcfTipoPagamentoDTO() { }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Tef { get; set; }
        public string ImprimeVinculado { get; set; }
        public string PermiteTroco { get; set; }
        public string TefTipoGp { get; set; }
        public string GeraParcelas { get; set; }
    }
}
