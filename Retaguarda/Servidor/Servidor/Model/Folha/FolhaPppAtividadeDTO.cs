using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaPppAtividadeDTO {
        public FolhaPppAtividadeDTO() { }
        public int Id { get; set; }
        public FolhaPppDTO FolhaPpp { get; set; }
        public System.Nullable<System.DateTime> DataInicio { get; set; }
        public System.Nullable<System.DateTime> DataFim { get; set; }
        public string Descricao { get; set; }
    }
}
