using System;
using System.Text;
using System.Collections.Generic;


namespace NFCe.DTO {
    
    public class NfceResolucaoDTO {
        public NfceResolucaoDTO() { }
        public int Id { get; set; }
        public string ResolucaoTela { get; set; }
        public System.Nullable<int> Largura { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public string ImagemTela { get; set; }
        public string ImagemMenu { get; set; }
        public string ImagemSubmenu { get; set; }

        public IList<NfcePosicaoComponentesDTO> ListaNfcePosicaoComponentes { get; set; }
    }
}
