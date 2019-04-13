using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class SindicatoDTO {
        public SindicatoDTO() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.Nullable<int> CodigoBanco { get; set; }
        public System.Nullable<int> CodigoAgencia { get; set; }
        public string ContaBanco { get; set; }
        public string CodigoCedente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public System.Nullable<int> MunicipioIbge { get; set; }
        public string Uf { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Email { get; set; }
        public string TipoSindicato { get; set; }
        public System.Nullable<System.DateTime> DataBase { get; set; }
        public System.Nullable<decimal> PisoSalarial { get; set; }
        public string Cnpj { get; set; }
        public string ClassificacaoContabilConta { get; set; }
    }
}
