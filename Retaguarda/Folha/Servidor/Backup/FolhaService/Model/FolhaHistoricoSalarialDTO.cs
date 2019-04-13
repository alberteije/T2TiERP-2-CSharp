using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaHistoricoSalarialDTO {
        public FolhaHistoricoSalarialDTO() { }
        public int Id { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string Competencia { get; set; }
        public System.Nullable<decimal> SalarioAtual { get; set; }
        public System.Nullable<decimal> PercentualAumento { get; set; }
        public System.Nullable<decimal> SalarioNovo { get; set; }
        public string ValidoAPartir { get; set; }
        public string Motivo { get; set; }
    }
}
