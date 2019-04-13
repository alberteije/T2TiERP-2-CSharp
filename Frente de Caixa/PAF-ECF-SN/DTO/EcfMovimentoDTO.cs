using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfMovimentoDTO {
        public EcfMovimentoDTO() 
        {
            EcfEmpresa = new EcfEmpresaDTO();
            EcfTurno = new EcfTurnoDTO();
            EcfImpressora = new EcfImpressoraDTO();
            EcfOperador = new EcfOperadorDTO();
            EcfCaixa = new EcfCaixaDTO();
        }
        public int Id { get; set; }
        public EcfEmpresaDTO EcfEmpresa { get; set; }
        public EcfTurnoDTO EcfTurno { get; set; }
        public EcfImpressoraDTO EcfImpressora { get; set; }
        public EcfOperadorDTO EcfOperador { get; set; }
        public EcfCaixaDTO EcfCaixa { get; set; }
        public int IdGerenteSupervisor { get; set; }
        public System.Nullable<System.DateTime> DataAbertura { get; set; }
        public string HoraAbertura { get; set; }
        public System.Nullable<System.DateTime> DataFechamento { get; set; }
        public string HoraFechamento { get; set; }
        public System.Nullable<decimal> TotalSuprimento { get; set; }
        public System.Nullable<decimal> TotalSangria { get; set; }
        public System.Nullable<decimal> TotalNaoFiscal { get; set; }
        public System.Nullable<decimal> TotalVenda { get; set; }
        public System.Nullable<decimal> TotalDesconto { get; set; }
        public System.Nullable<decimal> TotalAcrescimo { get; set; }
        public System.Nullable<decimal> TotalFinal { get; set; }
        public System.Nullable<decimal> TotalRecebido { get; set; }
        public System.Nullable<decimal> TotalTroco { get; set; }
        public System.Nullable<decimal> TotalCancelado { get; set; }
        public string StatusMovimento { get; set; }

        public IList<EcfFechamentoDTO> ListaEcfFechamento { get; set; }
        public IList<EcfSuprimentoDTO> ListaEcfSuprimento { get; set; }
        public IList<EcfSangriaDTO> ListaEcfSangria { get; set; }
        public IList<EcfDocumentosEmitidosDTO> ListaEcfDocumentosEmitidos { get; set; }
        public IList<EcfRecebimentoNaoFiscalDTO> ListaEcfRecebimentoNaoFiscal { get; set; }

    }
}
