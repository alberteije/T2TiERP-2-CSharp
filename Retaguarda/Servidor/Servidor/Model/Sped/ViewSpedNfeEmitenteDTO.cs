using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewSpedNfeEmitenteDTO {
        public ViewSpedNfeEmitenteDTO() { }
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public int CodigoMunicipio { get; set; }
        public string Suframa { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
    }
}
