using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfCaixaDTO {
        public EcfCaixaDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
    }
}
