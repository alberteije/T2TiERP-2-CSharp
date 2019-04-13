using System;
using System.Text;
using System.Collections.Generic;


namespace ConciliacaoContabilService.Model {
    
    public class ContabilLoteDTO {
        public ContabilLoteDTO() { }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Liberado { get; set; }
        public System.Nullable<System.DateTime> DataInclusao { get; set; }
        public System.Nullable<System.DateTime> DataLiberacao { get; set; }
        public string Programado { get; set; }
    }
}
