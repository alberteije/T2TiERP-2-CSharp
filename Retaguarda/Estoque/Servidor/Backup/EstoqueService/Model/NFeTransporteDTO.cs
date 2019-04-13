using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NFeTransporteDTO {
        public NFeTransporteDTO() { }
        public int id { get; set; }
        public int idNFeCabecalho { get; set; }
        public string modalidadeFrete { get; set; }
        public string cpfCnpj { get; set; }
        public string nome { get; set; }
        public string inscricaoEstadual { get; set; }
        public string endereco { get; set; }
        public string nomeMunicipio { get; set; }
        public string uf { get; set; }
        public System.Nullable<decimal> valorServico { get; set; }
        public System.Nullable<decimal> valorBcRetencaoIcms { get; set; }
        public System.Nullable<decimal> aliquotaRetencaoIcms { get; set; }
        public System.Nullable<decimal> valorIcmsRetido { get; set; }
        public System.Nullable<int> cfop { get; set; }
        public System.Nullable<int> municipio { get; set; }
        public string placaVeiculo { get; set; }
        public string ufVeiculo { get; set; }
        public string rntcVeiculo { get; set; }
        public string vagao { get; set; }
        public string balsa { get; set; }
    }
}
