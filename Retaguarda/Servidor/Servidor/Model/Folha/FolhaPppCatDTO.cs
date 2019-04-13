using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class FolhaPppCatDTO {
        public FolhaPppCatDTO() { }
        public int Id { get; set; }
        public FolhaPppDTO FolhaPpp { get; set; }
        public System.Nullable<int> NumeroCat { get; set; }
        public System.Nullable<System.DateTime> DataAfastamento { get; set; }
        public System.Nullable<System.DateTime> DataRegistro { get; set; }
    }
}
