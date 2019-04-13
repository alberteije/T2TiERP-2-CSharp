using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class CfopDTO {
        public CfopDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public string Descricao { get; set; }
        public string Aplicacao { get; set; }
    }
}
