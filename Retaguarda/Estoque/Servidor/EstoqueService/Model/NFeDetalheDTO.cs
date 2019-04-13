using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class NFeDetalheDTO {
        public NFeDetalheDTO() { }
        public int id { get; set; }
        public int idProduto { get; set; }
        public int idNFeCabecalho { get; set; }
        public System.Nullable<int> numeroItem { get; set; }
        public string codigoProduto { get; set; }
        public string gtin { get; set; }
        public string nomeProduto { get; set; }
        public string ncm { get; set; }
        public System.Nullable<int> exTipi { get; set; }
        public System.Nullable<int> cfop { get; set; }
        public string unidadeComercial { get; set; }
        public System.Nullable<decimal> quantidadeComercial { get; set; }
        public System.Nullable<decimal> valorUnitarioComercial { get; set; }
        public System.Nullable<decimal> valorBrutoProduto { get; set; }
        public string gtinUnidadeTributavel { get; set; }
        public string unidadeTributavel { get; set; }
        public System.Nullable<decimal> quantidadeTributavel { get; set; }
        public System.Nullable<decimal> valorUnitarioTributavel { get; set; }
        public System.Nullable<decimal> valorFrete { get; set; }
        public System.Nullable<decimal> valorSeguro { get; set; }
        public System.Nullable<decimal> valorDesconto { get; set; }
        public System.Nullable<decimal> valorOutrasDespesas { get; set; }
        public string entraTotal { get; set; }
        public System.Nullable<decimal> valorSubtotal { get; set; }
        public System.Nullable<decimal> valorTotal { get; set; }
        public string numeroPedidoCompra { get; set; }
        public System.Nullable<int> itemPedidoCompra { get; set; }
        public string informacoesAdicionais { get; set; }

        public NfeDetalheImpostoCofinsDTO impostoCofins { get; set; }
        public NfeDetalheImpostoIcmsDTO impostoIcms { get; set; }
        public NfeDetalheImpostoIiDTO impostoII { get; set; }
        public NfeDetalheImpostoIpiDTO impostoIpi { get; set; }
        public NfeDetalheImpostoIssqnDTO impostoIss { get; set; }
        public NfeDetalheImpostoPisDTO impostoPis { get; set; }

    }
}
