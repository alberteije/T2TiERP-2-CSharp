/********************************************************************************
Title: T2TiPDV
Description: VO relacionado à tabela ECF_RESOLUCAO

The MIT License

Copyright: Copyright (C) 2014 T2Ti.COM

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

       The author may be contacted at:
           t2ti.com@gmail.com

@author Albert Eije
@version 1.0
********************************************************************************/


using System;

namespace ConfiguraPAFECF.VO
{


    public class ResolucaoVO
    {


        private int FID;
        private string FRESOLUCAO_TELA;
        private int FLARGURA;
        private int FALTURA;
        private string FIMAGEM_TELA;
        private string FIMAGEM_MENU;
        private string FIMAGEM_SUBMENU;
        private string FHOTTRACK_COLOR;
        private string FITEM_STYLE_FONT_NAME;
        private string FITEM_STYLE_FONT_COLOR;
        private string FITEM_SEL_STYLE_COLOR;
        private string FLABEL_TOTAL_GERAL_FONT_COLOR;
        private string FITEM_STYLE_FONT_STYLE;
        private string FEDITS_COLOR;
        private string FEDITS_FONT_COLOR;
        private string FEDITS_DISABLED_COLOR;
        private string FEDITS_FONT_NAME;
        private string FEDITS_FONT_STYLE;



        public int Id
        {
            get
            {
                return FID;
            }
            set
            {
                FID = value;
            }
        }


        public String ResolucaoTela
        {
            get
            {
                return FRESOLUCAO_TELA;
            }
            set
            {
                FRESOLUCAO_TELA = value;
            }
        }


        public int Largura
        {
            get
            {
                return FLARGURA;
            }
            set
            {
                FLARGURA = value;
            }
        }


        public int Altura
        {
            get
            {
                return FALTURA;
            }
            set
            {
                FALTURA = value;
            }
        }


        public String ImagemTela
        {
            get
            {
                return FIMAGEM_TELA;
            }
            set
            {
                FIMAGEM_TELA = value;
            }
        }


        public String ImagemMenu
        {
            get
            {
                return FIMAGEM_MENU;
            }
            set
            {
                FIMAGEM_MENU = value;
            }
        }


        public String ImagemSubMenu
        {
            get
            {
                return FIMAGEM_SUBMENU;
            }
            set
            {
                FIMAGEM_SUBMENU = value;
            }
        }


        public String HotTrackColor
        {
            get
            {
                return FHOTTRACK_COLOR;
            }
            set
            {
                FHOTTRACK_COLOR = value;
            }
        }


        public String ItemStyleFontName
        {
            get
            {
                return FITEM_STYLE_FONT_NAME;
            }
            set
            {
                FITEM_STYLE_FONT_NAME = value;
            }
        }


        public String ItemStyleFontColor
        {
            get
            {
                return FITEM_STYLE_FONT_COLOR;
            }
            set
            {
                FITEM_STYLE_FONT_COLOR = value;
            }
        }


        public String ItemSelStyleColor
        {
            get
            {
                return FITEM_SEL_STYLE_COLOR;
            }
            set
            {
                FITEM_SEL_STYLE_COLOR = value;
            }
        }


        public String LabelTotalGeralFontColor
        {
            get
            {
                return FLABEL_TOTAL_GERAL_FONT_COLOR;
            }
            set
            {
                FLABEL_TOTAL_GERAL_FONT_COLOR = value;
            }
        }


        public String ItemStyleFontStyle
        {
            get
            {
                return FITEM_STYLE_FONT_STYLE;
            }
            set
            {
                FITEM_STYLE_FONT_STYLE = value;
            }
        }


        public String EditColor
        {
            get
            {
                return FEDITS_COLOR;
            }
            set
            {
                FEDITS_COLOR = value;
            }
        }


        public String EditFontColor
        {
            get
            {
                return FEDITS_FONT_COLOR;
            }
            set
            {
                FEDITS_FONT_COLOR = value;
            }
        }


        public String EditDisabledColor
        {
            get
            {
                return FEDITS_DISABLED_COLOR;
            }
            set
            {
                FEDITS_DISABLED_COLOR = value;
            }
        }


        public String EditFontName
        {
            get
            {
                return FEDITS_FONT_NAME;
            }
            set
            {
                FEDITS_FONT_NAME = value;
            }
        }


        public String EditFontStyle
        {
            get
            {
                return FEDITS_FONT_STYLE;
            }
            set
            {
                FEDITS_FONT_STYLE = value;
            }
        }


    }

}
