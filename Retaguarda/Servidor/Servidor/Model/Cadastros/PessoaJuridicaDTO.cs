using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class PessoaJuridicaDTO {
        public PessoaJuridicaDTO() { }
        public int Id { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public string Cnpj { get; set; }
        public string Fantasia { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public System.Nullable<System.DateTime> DataConstituicao { get; set; }
        public string TipoRegime { get; set; }
        public string Crt { get; set; }
        public string Suframa { get; set; }
    }
}
