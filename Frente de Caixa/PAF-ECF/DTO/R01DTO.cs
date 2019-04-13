using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class R01DTO {
        public R01DTO() { }
        public int Id { get; set; }
        public string SerieEcf { get; set; }
        public string CnpjEmpresa { get; set; }
        public string CnpjSh { get; set; }
        public string InscricaoEstadualSh { get; set; }
        public string InscricaoMunicipalSh { get; set; }
        public string DenominacaoSh { get; set; }
        public string NomePafEcf { get; set; }
        public string VersaoPafEcf { get; set; }
        public string Md5PafEcf { get; set; }
        public System.Nullable<System.DateTime> DataInicial { get; set; }
        public System.Nullable<System.DateTime> DataFinal { get; set; }
        public string VersaoEr { get; set; }
        public string NumeroLaudoPaf { get; set; }
        public string RazaoSocialSh { get; set; }
        public string EnderecoSh { get; set; }
        public string NumeroSh { get; set; }
        public string ComplementoSh { get; set; }
        public string BairroSh { get; set; }
        public string CidadeSh { get; set; }
        public string CepSh { get; set; }
        public string UfSh { get; set; }
        public string TelefoneSh { get; set; }
        public string ContatoSh { get; set; }
        public string PrincipalExecutavel { get; set; }
        public string Logss { get; set; }
    }
}
