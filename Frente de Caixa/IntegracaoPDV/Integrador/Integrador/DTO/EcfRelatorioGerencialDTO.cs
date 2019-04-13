using System;
using System.Text;
using System.Collections.Generic;


namespace Integrador.DTO {
    
    public class EcfRelatorioGerencialDTO {
        public EcfRelatorioGerencialDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> X { get; set; }
        public System.Nullable<int> MeiosPagamento { get; set; }
        public System.Nullable<int> DavEmitidos { get; set; }
        public System.Nullable<int> IdentificacaoPaf { get; set; }
        public System.Nullable<int> ParametrosConfiguracao { get; set; }
        public System.Nullable<int> Outros { get; set; }
    }
}
