using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FiscalInscricoesSubstitutasDTO {
        public FiscalInscricoesSubstitutasDTO() { }
        public int Id { get; set; }
        public FiscalParametroDTO FiscalParametros { get; set; }
        public string Uf { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Pmpf { get; set; }
    }
}
