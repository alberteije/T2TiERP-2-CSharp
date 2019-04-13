using System;
using System.Text;
using System.Collections.Generic;


namespace FolhaService.Model {
    
    public class FolhaPppExameMedicoDTO {
        public FolhaPppExameMedicoDTO() { }
        public int Id { get; set; }
        public int? IdFolhaPpp { get; set; }
        public System.Nullable<System.DateTime> DataUltimo { get; set; }
        public string Tipo { get; set; }
        public string Natureza { get; set; }
        public string Exame { get; set; }
        public string IndicacaoResultados { get; set; }
    }
}
