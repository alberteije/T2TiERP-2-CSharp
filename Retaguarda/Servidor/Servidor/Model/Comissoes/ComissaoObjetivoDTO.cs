using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ComissaoObjetivoDTO {
        public ComissaoObjetivoDTO() { }
        public int Id { get; set; }
        public ComissaoPerfilDTO ComissaoPerfil { get; set; }
        public ProdutoDTO Produto { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FormaPagamento { get; set; }
        public System.Nullable<decimal> TaxaPagamento { get; set; }
        public System.Nullable<decimal> ValorPagamento { get; set; }
        public System.Nullable<decimal> ValorMeta { get; set; }
        public System.Nullable<decimal> Quantidade { get; set; }
    }
}
