using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceMovimentoDTO {
        public NfceMovimentoDTO() 
        {
            Empresa = new EmpresaDTO();
            NfceTurno = new NfceTurnoDTO();
            NfceOperador = new NfceOperadorDTO();
            NfceCaixa = new NfceCaixaDTO();
        }

        public int Id { get; set; }
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

        public EmpresaDTO Empresa { get; set; }
        public NfceTurnoDTO NfceTurno { get; set; }
        public NfceOperadorDTO NfceOperador { get; set; }
        public NfceCaixaDTO NfceCaixa { get; set; }

        public IList<NfceFechamentoDTO> ListaNfceFechamento { get; set; }
        public IList<NfceSuprimentoDTO> ListaNfceSuprimento { get; set; }
        public IList<NfceSangriaDTO> ListaNfceSangria { get; set; }
    }
}
