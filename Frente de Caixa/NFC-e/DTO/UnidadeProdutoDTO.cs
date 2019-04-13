using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class UnidadeProdutoDTO {
        public UnidadeProdutoDTO() { }
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public string PodeFracionar { get; set; }
    }
}
