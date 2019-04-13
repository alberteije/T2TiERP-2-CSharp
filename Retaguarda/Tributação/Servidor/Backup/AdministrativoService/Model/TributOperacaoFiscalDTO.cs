using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributOperacaoFiscalDTO {
        public TributOperacaoFiscalDTO() { }
        public int Id { get; set; }
        public EmpresaDTO Empresa { get; set; }
        public string Descricao { get; set; }
        public string DescricaoNaNf { get; set; }
        public System.Nullable<int> Cfop { get; set; }
        public string Observacao { get; set; }
    }
}
