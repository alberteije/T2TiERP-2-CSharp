using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContabilIndiceDTO {
        public ContabilIndiceDTO() { }
        public int Id { get; set; }
        public IndiceEconomicoDTO IndiceEconomico { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Periodicidade { get; set; }
        public System.Nullable<System.DateTime> DiarioAPartirDe { get; set; }
        public string MensalMesAno { get; set; }
    }
}
