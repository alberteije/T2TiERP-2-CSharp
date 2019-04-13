using System;
using System.Text;
using System.Collections.Generic;


namespace SAT.DTO {
    
    public class SATConfiguracaoDTO {
        public SATConfiguracaoDTO() { }

        public string Modelo { get; set; }
        public string ArqLOG { get; set; }
        public string NomeDLL { get; set; }
        public int ide_numeroCaixa { get; set; }
        public int ide_tpAmb { get; set; } //0-homologação | 1-produção
        public string ide_CNPJ { get; set; }
        public string emit_CNPJ { get; set; }
        public string emit_IE { get; set; }
        public string emit_IM { get; set; }
        public int emit_cRegTrib { get; set; } //0-simples | 1-normal

        public bool SalvarCFe { get; set; }
        public bool SalvarCFeCanc { get; set; }
        public bool SalvarEnvio { get; set; }
        public bool ExtratoResumido { get; set; }
        
    }
}
