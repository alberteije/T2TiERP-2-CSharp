using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class EmpresaTransporteDTO {
        public EmpresaTransporteDTO() { }
        public int Id { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }
        public string ClassificacaoContabilConta { get; set; }
    }
}
