/********************************************************************************
Title: T2TiPDV
Description: VO relacionado à tabela ECF_POSICAO_COMPONENTES

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


    public class PosicaoComponentesVO
    {


        private int FID;
        private int FID_ECF_RESOLUCAO;
        private string FNOME;
        private int FALTURA;
        private int FLARGURA;
        private int FTOPO;
        private int FESQUERDA;
        private int FTAMANHO_FONTE;
        private string FTEXTO;



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


        public int IdResolucao
        {
            get
            {
                return FID_ECF_RESOLUCAO;
            }
            set
            {
                FID_ECF_RESOLUCAO = value;
            }
        }


        public String NomeComponente
        {
            get
            {
                return FNOME;
            }
            set
            {
                FNOME = value;
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


        public int Topo
        {
            get
            {
                return FTOPO;
            }
            set
            {
                FTOPO = value;
            }
        }


        public int Esquerda
        {
            get
            {
                return FESQUERDA;
            }
            set
            {
                FESQUERDA = value;
            }
        }


        public int TamanhoFonte
        {
            get
            {
                return FTAMANHO_FONTE;
            }
            set
            {
                FTAMANHO_FONTE = value;
            }
        }


        public String TextoComponente
        {
            get
            {
                return FTEXTO;
            }
            set
            {
                FTEXTO = value;
            }
        }


    }

}


