using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeTransporteDTO {
        public NfeTransporteDTO() { }
        public int Id { get; set; }
        public TransportadoraDTO Transportadora { get; set; }
        public int IdNfeCabecalho { get; set; }
        public System.Nullable<int> ModalidadeFrete { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string InscricaoEstadual { get; set; }
        public string EmpresaEndereco { get; set; }
        public string NomeMunicipio { get; set; }
        public string Uf { get; set; }
        public System.Nullable<decimal> ValorServico { get; set; }
        public System.Nullable<decimal> ValorBcRetencaoIcms { get; set; }
        public System.Nullable<decimal> AliquotaRetencaoIcms { get; set; }
        public System.Nullable<decimal> ValorIcmsRetido { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public System.Nullable<int> Municipio { get; set; }
        public string PlacaVeiculo { get; set; }
        public string UfVeiculo { get; set; }
        public string RntcVeiculo { get; set; }
        public string Vagao { get; set; }
        public string Balsa { get; set; }
    }
}
