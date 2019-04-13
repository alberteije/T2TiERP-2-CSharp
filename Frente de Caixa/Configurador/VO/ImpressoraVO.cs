/********************************************************************************
Title: T2TiPDV
Description: VO relacionado à tabela ECF_IMPRESSORA

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


    public class ImpressoraVO
    {


        private int FID;
        private int FNUMERO;
        private string FCODIGO;
        private string FSERIE;
        private string FIDENTIFICACAO;
        private string FMC;
        private string FMD;
        private string FVR;
        private string FTIPO;
        private string FMARCA;
        private string FMODELO;
        private string FMODELO_ACBR;
        private string FMODELO_DOCUMENTO_FISCAL;
        private string FVERSAO;
        private string FLE;
        private string FLEF;
        private string FMFD;
        private string FLACRE_NA_MFD;
        private string FDOCTO;
        private string FNUMERO_ECF;
        private DateTime FDATA_INSTALACAO_SB;
        private string FHORA_INSTALACAO_SB;



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


        public int Numero
        {
            get
            {
                return FNUMERO;
            }
            set
            {
                FNUMERO = value;
            }
        }


        public String Codigo
        {
            get
            {
                return FCODIGO;
            }
            set
            {
                FCODIGO = value;
            }
        }


        public String Serie
        {
            get
            {
                return FSERIE;
            }
            set
            {
                FSERIE = value;
            }
        }


        public String Identificacao
        {
            get
            {
                return FIDENTIFICACAO;
            }
            set
            {
                FIDENTIFICACAO = value;
            }
        }


        public String MC
        {
            get
            {
                return FMC;
            }
            set
            {
                FMC = value;
            }
        }


        public String MD
        {
            get
            {
                return FMD;
            }
            set
            {
                FMD = value;
            }
        }


        public String VR
        {
            get
            {
                return FVR;
            }
            set
            {
                FVR = value;
            }
        }


        public String Tipo
        {
            get
            {
                return FTIPO;
            }
            set
            {
                FTIPO = value;
            }
        }


        public String Marca
        {
            get
            {
                return FMARCA;
            }
            set
            {
                FMARCA = value;
            }
        }


        public String Modelo
        {
            get
            {
                return FMODELO;
            }
            set
            {
                FMODELO = value;
            }
        }


        public String ModeloACBr
        {
            get
            {
                return FMODELO_ACBR;
            }
            set
            {
                FMODELO_ACBR = value;
            }
        }


        public String ModeloDocumentoFiscal
        {
            get
            {
                return FMODELO_DOCUMENTO_FISCAL;
            }
            set
            {
                FMODELO_DOCUMENTO_FISCAL = value;
            }
        }


        public String Versao
        {
            get
            {
                return FVERSAO;
            }
            set
            {
                FVERSAO = value;
            }
        }


        public String LE
        {
            get
            {
                return FLE;
            }
            set
            {
                FLE = value;
            }
        }


        public String LEF
        {
            get
            {
                return FLEF;
            }
            set
            {
                FLEF = value;
            }
        }


        public String MFD
        {
            get
            {
                return FMFD;
            }
            set
            {
                FMFD = value;
            }
        }


        public String LacreNaMFD
        {
            get
            {
                return FLACRE_NA_MFD;
            }
            set
            {
                FLACRE_NA_MFD = value;
            }
        }


        public String DOCTO
        {
            get
            {
                return FDOCTO;
            }
            set
            {
                FDOCTO = value;
            }
        }


        public String NumeroEcf
        {
            get
            {
                return FNUMERO_ECF;
            }
            set
            {
                FNUMERO_ECF = value;
            }
        }


        public DateTime DataInstalacaoSb
        {
            get
            {
                return FDATA_INSTALACAO_SB;
            }
            set
            {
                FDATA_INSTALACAO_SB = value;
            }
        }


        public String HoraInstalacaoSb
        {
            get
            {
                return FHORA_INSTALACAO_SB;
            }
            set
            {
                FHORA_INSTALACAO_SB = value;
            }
        }


    }


}