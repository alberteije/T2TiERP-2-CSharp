using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfeConfiguracaoDTO {
        public NfeConfiguracaoDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string CertificadoDigitalSerie { get; set; }
        public string CertificadoDigitalCaminho { get; set; }
        public string CertificadoDigitalSenha { get; set; }
        public System.Nullable<int> TipoEmissao { get; set; }
        public System.Nullable<int> FormatoImpressaoDanfe { get; set; }
        public System.Nullable<int> ProcessoEmissao { get; set; }
        public string VersaoProcessoEmissao { get; set; }
        public string CaminhoLogomarca { get; set; }
        public string SalvarXml { get; set; }
        public string CaminhoSalvarXml { get; set; }
        public string CaminhoSchemas { get; set; }
        public string CaminhoArquivoDanfe { get; set; }
        public string CaminhoSalvarPdf { get; set; }
        public string WebserviceUf { get; set; }
        public System.Nullable<int> WebserviceAmbiente { get; set; }
        public string WebserviceProxyHost { get; set; }
        public System.Nullable<int> WebserviceProxyPorta { get; set; }
        public string WebserviceProxyUsuario { get; set; }
        public string WebserviceProxySenha { get; set; }
        public string WebserviceVisualizar { get; set; }
        public string EmailServidorSmtp { get; set; }
        public System.Nullable<int> EmailPorta { get; set; }
        public string EmailUsuario { get; set; }
        public string EmailSenha { get; set; }
        public string EmailAssunto { get; set; }
        public string EmailAutenticaSsl { get; set; }
        public string EmailTexto { get; set; }
    }
}
