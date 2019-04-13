using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class NfeDetalheDTO {
        public NfeDetalheDTO() { }
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public NfeDetalheImpostoCofinsDTO NfeDetalheImpostoCofins { get; set; }
        public NfeDetalheImpostoIcmsDTO NfeDetalheImpostoIcms { get; set; }
        public NfeDetalheImpostoIiDTO NfeDetalheImpostoII { get; set; }
        public NfeDetalheImpostoIpiDTO NfeDetalheImpostoIpi { get; set; }
        public NfeDetalheImpostoIssqnDTO NfeDetalheImpostoIssqn { get; set; }
        public NfeDetalheImpostoPisDTO NfeDetalheImpostoPis { get; set; }
        public NfeDetEspecificoVeiculoDTO NfeDetEspecificoVeiculo { get; set; }
        public NfeDetEspecificoCombustivelDTO NfeDetEspecificoCombustivel { get; set; }
        public int IdNfeCabecalho { get; set; }
        public System.Nullable<int> NumeroItem { get; set; }
        public string CodigoProduto { get; set; }
        public string Gtin { get; set; }
        public string NomeProduto { get; set; }
        public string Ncm { get; set; }
        public string Nve { get; set; }
        public System.Nullable<int> ExTipi { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public string UnidadeComercial { get; set; }
        public System.Nullable<decimal> QuantidadeComercial { get; set; }
        public System.Nullable<decimal> ValorUnitarioComercial { get; set; }
        public System.Nullable<decimal> ValorBrutoProduto { get; set; }
        public string GtinUnidadeTributavel { get; set; }
        public string UnidadeTributavel { get; set; }
        public System.Nullable<decimal> QuantidadeTributavel { get; set; }
        public System.Nullable<decimal> ValorUnitarioTributavel { get; set; }
        public System.Nullable<decimal> ValorFrete { get; set; }
        public System.Nullable<decimal> ValorSeguro { get; set; }
        public System.Nullable<decimal> ValorDesconto { get; set; }
        public System.Nullable<decimal> ValorOutrasDespesas { get; set; }
        public System.Nullable<int> EntraTotal { get; set; }
        public System.Nullable<decimal> ValorSubtotal { get; set; }
        public System.Nullable<decimal> ValorTotal { get; set; }
        public string NumeroPedidoCompra { get; set; }
        public System.Nullable<int> ItemPedidoCompra { get; set; }
        public string InformacoesAdicionais { get; set; }
        public string NumeroFci { get; set; }
        public string NumeroRecopi { get; set; }
        public System.Nullable<decimal> ValorTotalTributos { get; set; }
        public System.Nullable<decimal> PercentualDevolvido { get; set; }
        public System.Nullable<decimal> ValorIpiDevolvido { get; set; }

        // Grupo I01
        public IList<NfeDeclaracaoImportacaoDTO> ListaNfeDeclaracaoImportacao { get; set; } //0:100
        // Grupo I03
        public IList<NfeExportacaoDTO> ListaNfeExportacao { get; set; } //0:500
        // Grupo K
        public IList<NfeDetEspecificoMedicamentoDTO> ListaNfeDetEspecificoMedicamento { get; set; } //0:500
        // Grupo L
        public IList<NfeDetEspecificoArmamentoDTO> ListaNfeDetEspecificoArmamento { get; set; } //0:500

    }
}
