using System;
using System.Text;
using System.Collections.Generic;


namespace PafEcf.DTO {
    
    public class EcfResolucaoDTO {
        public EcfResolucaoDTO() { }
        public int Id { get; set; }
        public string ResolucaoTela { get; set; }
        public System.Nullable<int> Largura { get; set; }
        public System.Nullable<int> Altura { get; set; }
        public string ImagemTela { get; set; }
        public string ImagemMenu { get; set; }
        public string ImagemSubmenu { get; set; }
        public string HottrackColor { get; set; }
        public string ItemStyleFontName { get; set; }
        public string ItemStyleFontColor { get; set; }
        public string ItemSelStyleColor { get; set; }
        public string LabelTotalGeralFontColor { get; set; }
        public string ItemStyleFontStyle { get; set; }
        public string EditsColor { get; set; }
        public string EditsFontColor { get; set; }
        public string EditsDisabledColor { get; set; }
        public string EditsFontName { get; set; }
        public string EditsFontStyle { get; set; }

        public IList<EcfPosicaoComponentesDTO> ListaEcfPosicaoComponentes { get; set; }
    }

}
