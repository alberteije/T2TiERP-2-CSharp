using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfeDetalheDTO {
        public NfeDetalheDTO() { }
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public NfeDetalheImpostoIcmsDTO NfeDetalheImpostoIcms { get; set; }
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
    }
}
