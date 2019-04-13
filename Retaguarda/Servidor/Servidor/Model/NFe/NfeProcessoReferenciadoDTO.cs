using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeProcessoReferenciadoDTO {
        public NfeProcessoReferenciadoDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string Identificador { get; set; }
        public string Origem { get; set; }
    }
}
