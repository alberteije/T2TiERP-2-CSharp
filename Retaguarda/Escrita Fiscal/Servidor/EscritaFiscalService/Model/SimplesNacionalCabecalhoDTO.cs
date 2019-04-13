using System;
using System.Text;
using System.Collections.Generic;


namespace EscritaFiscalService.Model {
    
    public class SimplesNacionalCabecalhoDTO {
        public SimplesNacionalCabecalhoDTO() { }
        public int? Id { get; set; }
        public System.Nullable<System.DateTime> VigenciaInicial { get; set; }
        public System.Nullable<System.DateTime> VigenciaFinal { get; set; }
        public string Anexo { get; set; }
        public string Tabela { get; set; }

        public IList<SimplesNacionalDetalheDTO> ListaSimplesNacionalDetalhe { get; set; }
    }
}
