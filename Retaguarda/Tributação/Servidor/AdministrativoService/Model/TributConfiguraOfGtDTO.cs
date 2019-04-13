using System;
using System.Text;
using System.Collections.Generic;


namespace AdministrativoService.Model {
    
    public class TributConfiguraOfGtDTO {
        public TributConfiguraOfGtDTO() { }
        public int Id { get; set; }
        public TributGrupoTributarioDTO TributGrupoTributario { get; set; }
        public TributOperacaoFiscalDTO TributOperacaoFiscal { get; set; }

        public IList<TributIpiDipiDTO> ListaTributIpiDipi { get; set; }
        public IList<TributPisCodApuracaoDTO> ListaTributPisCodApuracao { get; set; }
        public IList<TributCofinsCodApuracaoDTO> ListaTributCofinsCodApuracao { get; set; }
        public IList<TributIcmsUfDTO> ListaTributIcmsUf { get; set; }
    }
}
