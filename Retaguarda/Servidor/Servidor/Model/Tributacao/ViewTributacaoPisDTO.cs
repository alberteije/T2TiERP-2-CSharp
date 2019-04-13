using System;
using System.Text;
using System.Collections.Generic;


namespace Servidor.Model {
    
    public class ViewTributacaoPisDTO {
        public ViewTributacaoPisDTO() { }
        public int Id { get; set; }
        public int IdTributGrupoTributario { get; set; }
        public int IdTributOperacaoFiscal { get; set; }
        public string CstPis { get; set; }
        public string EfdTabela435 { get; set; }
        public string ModalidadeBaseCalculo { get; set; }
        public System.Nullable<decimal> PorcentoBaseCalculo { get; set; }
        public System.Nullable<decimal> AliquotaPorcento { get; set; }
        public System.Nullable<decimal> AliquotaUnidade { get; set; }
        public System.Nullable<decimal> ValorPrecoMaximo { get; set; }
        public System.Nullable<decimal> ValorPautaFiscal { get; set; }
    }
}
