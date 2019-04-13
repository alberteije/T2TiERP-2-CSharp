using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaPppFatorRiscoDTO {
        public FolhaPppFatorRiscoDTO() { }
        public int Id { get; set; }
        public int? IdFolhaPpp { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public string Tipo { get; set; }
        public string FatorRisco { get; set; }
        public string Intensidade { get; set; }
        public string TecnicaUtilizada { get; set; }
        public string EpcEficaz { get; set; }
        public string EpiEficaz { get; set; }
        public System.Nullable<int> CaEpi { get; set; }
        public string AtendimentoNr061 { get; set; }
        public string AtendimentoNr062 { get; set; }
        public string AtendimentoNr063 { get; set; }
        public string AtendimentoNr064 { get; set; }
        public string AtendimentoNr065 { get; set; }
    }
}
