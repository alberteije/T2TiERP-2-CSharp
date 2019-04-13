using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeLocalRetiradaDTO {
        public NfeLocalRetiradaDTO() { }
        public int Id { get; set; }
        public int IdNfeCabecalho { get; set; }
        public string CpfCnpj { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public System.Nullable<int> CodigoMunicipio { get; set; }
        public string NomeMunicipio { get; set; }
        public string Uf { get; set; }
    }
}
