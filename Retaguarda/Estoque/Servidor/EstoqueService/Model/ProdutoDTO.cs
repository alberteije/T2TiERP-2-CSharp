using System;
using System.Text;
using System.Collections.Generic;


namespace EstoqueService.Model {
    
    public class ProdutoDTO {
        public ProdutoDTO() { }
        public int id { get; set; }
        public TributIcmsCustomCabDTO TributIcmsCustomCab { get; set; }
        public UnidadeProdutoDTO UnidadeProduto { get; set; }
        public AlmoxarifadoDTO Almoxarifado { get; set; }
        public TributGrupoTributarioDTO TributGrupoTributario { get; set; }
        public ProdutoMarcaDTO ProdutoMarca { get; set; }
        public ProdutoSubGrupoDTO ProdutoSubGrupo { get; set; }
        public string gtin { get; set; }
        public string codigoInterno { get; set; }
        public string ncm { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string descricaoPdv { get; set; }
        public System.Nullable<decimal> valorCompra { get; set; }
        public System.Nullable<decimal> valorVenda { get; set; }
        public System.Nullable<decimal> precoVendaMinimo { get; set; }
        public System.Nullable<decimal> precoSugerido { get; set; }
        public System.Nullable<decimal> custoMedioLiquido { get; set; }
        public System.Nullable<decimal> precoLucroZero { get; set; }
        public System.Nullable<decimal> precoLucroMinimo { get; set; }
        public System.Nullable<decimal> precoLucroMaximo { get; set; }
        public System.Nullable<decimal> markup { get; set; }
        public System.Nullable<decimal> quantidadeEstoque { get; set; }
        public System.Nullable<decimal> quantidadeEstoqueAnterior { get; set; }
        public System.Nullable<decimal> estoqueMinimo { get; set; }
        public System.Nullable<decimal> estoqueMaximo { get; set; }
        public System.Nullable<decimal> estoqueIdeal { get; set; }
        public string excluido { get; set; }
        public string inativo { get; set; }
        public System.Nullable<System.DateTime> dataCadastro { get; set; }
        public string exTipi { get; set; }
        public string codigoLst { get; set; }
        public string classeAbc { get; set; }
        public string iat { get; set; }
        public string ippt { get; set; }
        public string tipoItemSped { get; set; }
        public System.Nullable<decimal> peso { get; set; }
        public System.Nullable<decimal> porcentoComissao { get; set; }
        public System.Nullable<decimal> pontoPedido { get; set; }
        public System.Nullable<decimal> loteEconomicoCompra { get; set; }
        public System.Nullable<decimal> aliquotaIcmsPaf { get; set; }
        public System.Nullable<decimal> aliquotaIssqnPaf { get; set; }
        public string totalizadorParcial { get; set; }
        public System.Nullable<int> codigoBalanca { get; set; }
        public System.Nullable<System.DateTime> dataAlteracao { get; set; }
        public string tipo { get; set; }
    }
}
