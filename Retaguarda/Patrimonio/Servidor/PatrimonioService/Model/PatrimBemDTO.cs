using System;
using System.Text;
using System.Collections.Generic;


namespace PatrimonioService.Model {
    
    public class PatrimBemDTO {
        public PatrimBemDTO() { }
        public int Id { get; set; }
        public PatrimTipoAquisicaoBemDTO PatrimTipoAquisicaoBem { get; set; }
        public PatrimEstadoConservacaoDTO PatrimEstadoConservacao { get; set; }
        public PatrimGrupoBemDTO PatrimGrupoBem { get; set; }
        public SetorDTO Setor { get; set; }
        public FornecedorDTO Fornecedor { get; set; }
        public ColaboradorDTO Colaborador { get; set; }
        public string NumeroNb { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string NumeroSerie { get; set; }
        public System.Nullable<System.DateTime> DataAquisicao { get; set; }
        public System.Nullable<System.DateTime> DataAceite { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataContabilizado { get; set; }
        public System.Nullable<System.DateTime> DataVistoria { get; set; }
        public System.Nullable<System.DateTime> DataMarcacao { get; set; }
        public System.Nullable<System.DateTime> DataBaixa { get; set; }
        public System.Nullable<System.DateTime> VencimentoGarantia { get; set; }
        public string NumeroNotaFiscal { get; set; }
        public string ChaveNfe { get; set; }
        public System.Nullable<decimal> ValorOriginal { get; set; }
        public System.Nullable<decimal> ValorCompra { get; set; }
        public System.Nullable<decimal> ValorAtualizado { get; set; }
        public System.Nullable<decimal> ValorBaixa { get; set; }
        public string Deprecia { get; set; }
        public string MetodoDepreciacao { get; set; }
        public System.Nullable<System.DateTime> InicioDepreciacao { get; set; }
        public System.Nullable<System.DateTime> UltimaDepreciacao { get; set; }
        public string TipoDepreciacao { get; set; }
        public System.Nullable<decimal> TaxaAnualDepreciacao { get; set; }
        public System.Nullable<decimal> TaxaMensalDepreciacao { get; set; }
        public System.Nullable<decimal> TaxaDepreciacaoAcelerada { get; set; }
        public System.Nullable<decimal> TaxaDepreciacaoIncentivada { get; set; }
        public string Funcao { get; set; }

        public IList<PatrimApoliceSeguroDTO> ListaPatrimApoliceSeguro { get; set; }
        public IList<PatrimDepreciacaoBemDTO> ListaPatrimDepreciacaoBem { get; set; }
        public IList<PatrimDocumentoBemDTO> ListaPatrimDocumentoBem { get; set; }
        public IList<PatrimMovimentacaoBemDTO> ListaPatrimMovimentacaoBem { get; set; }
    }
}
