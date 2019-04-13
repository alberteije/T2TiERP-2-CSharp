using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeAcessoXmlDTO {
        public NfeAcessoXmlDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
    }
}
