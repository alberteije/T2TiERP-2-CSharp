using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfImpressoraDTO {
        public EcfImpressoraDTO() { }
        public int Id { get; set; }
        public System.Nullable<int> Numero { get; set; }
        public string Codigo { get; set; }
        public string Serie { get; set; }
        public string Identificacao { get; set; }
        public string Mc { get; set; }
        public string Md { get; set; }
        public string Vr { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ModeloAcbr { get; set; }
        public string ModeloDocumentoFiscal { get; set; }
        public string Versao { get; set; }
        public string Le { get; set; }
        public string Lef { get; set; }
        public string Mfd { get; set; }
        public string LacreNaMfd { get; set; }
        public string Docto { get; set; }
        public System.Nullable<System.DateTime> DataInstalacaoSb { get; set; }
        public string HoraInstalacaoSb { get; set; }
    }
}
