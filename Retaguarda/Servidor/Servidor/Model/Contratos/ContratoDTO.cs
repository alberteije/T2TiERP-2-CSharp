using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ContratoDTO {
        public ContratoDTO() { }
        public int Id { get; set; }
        public ContratoSolicitacaoServicoDTO ContratoSolicitacaoServico { get; set; }
        public TipoContratoDTO TipoContrato { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.Nullable<System.DateTime> DataCadastro { get; set; }
        public System.Nullable<System.DateTime> DataInicioVigencia { get; set; }
        public System.Nullable<System.DateTime> DataFimVigencia { get; set; }
        public string DiaFaturamento { get; set; }
        public System.Nullable<decimal> Valor { get; set; }
        public System.Nullable<int> QuantidadeParcelas { get; set; }
        public System.Nullable<int> IntervaloEntreParcelas { get; set; }
        public string Observacao { get; set; }
        public string ClassificacaoContabilConta { get; set; }
    }
}
