using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class ProdutoDTO {
        public ProdutoDTO() { }
        public int Id { get; set; }
        public UnidadeProdutoDTO UnidadeProduto { get; set; }
        public string Gtin { get; set; }
        public string CodigoInterno { get; set; }
        public string Ncm { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DescricaoPdv { get; set; }
        public System.Nullable<decimal> ValorCompra { get; set; }
        public System.Nullable<decimal> ValorVenda { get; set; }
        public System.Nullable<decimal> PrecoVendaMinimo { get; set; }
        public System.Nullable<decimal> PrecoSugerido { get; set; }
        public System.Nullable<decimal> CustoMedioLiquido { get; set; }
        public System.Nullable<decimal> PrecoLucroZero { get; set; }
        public System.Nullable<decimal> PrecoLucroMinimo { get; set; }
        public System.Nullable<decimal> PrecoLucroMaximo { get; set; }
        public System.Nullable<decimal> Markup { get; set; }
        public System.Nullable<decimal> QuantidadeEstoque { get; set; }
        public System.Nullable<decimal> QuantidadeEstoqueAnterior { get; set; }
        public System.Nullable<decimal> EstoqueMinimo { get; set; }
        public System.Nullable<decimal> EstoqueMaximo { get; set; }
        public System.Nullable<decimal> EstoqueIdeal { get; set; }
        public string Excluido { get; set; }
        public string Inativo { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public string FotoProduto { get; set; }
        public string ExTipi { get; set; }
        public string CodigoLst { get; set; }
        public string ClasseAbc { get; set; }
        public string Iat { get; set; }
        public string Ippt { get; set; }
        public string TipoItemSped { get; set; }
        public System.Nullable<decimal> Peso { get; set; }
        public System.Nullable<decimal> PorcentoComissao { get; set; }
        public System.Nullable<decimal> PontoPedido { get; set; }
        public System.Nullable<decimal> LoteEconomicoCompra { get; set; }
        public System.Nullable<decimal> AliquotaIcmsPaf { get; set; }
        public System.Nullable<decimal> AliquotaIssqnPaf { get; set; }
        public string TotalizadorParcial { get; set; }
        public System.Nullable<int> CodigoBalanca { get; set; }
        public System.Nullable<System.DateTime> DataAlteracao { get; set; }
        public string Tipo { get; set; }
    }
}
