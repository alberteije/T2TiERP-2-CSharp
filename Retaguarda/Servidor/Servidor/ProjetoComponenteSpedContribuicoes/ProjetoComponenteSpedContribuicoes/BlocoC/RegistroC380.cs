/**
 * <p>Title: T2TiPDV</p>
 *
 * <p>Description: Sped Fiscal</p>
 *
 * <p>The MIT License</p>
 *
 * <p>Copyright: Copyright (C) 2013 T2Ti.COM</p>
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 * The author may be contacted at: t2ti.com@gmail.com</p>
 *
 * @author Albert Eije (T2Ti.COM)
 * @version 2.0
 */
using System;
using System.Collections.Generic;

namespace ComponenteSpedContribuicoes
{

    public class RegistroC380
    {

        private String codMod; // Código do modelo do documento fiscal, conforme a Tabela 4.1.1 (Código 02 – Nota Fiscal de Venda a Consumidor) 
        private DateTime dtDocIni; // Data de Emissão Inicial dos Documentos 
        private DateTime dtDocFin; //Data de Emissão Final dos Documentos
        private String numDocIni; // Número do documento fiscal inicial
        private String numDocFin; // Número do documento fiscal final
        private Decimal vlDoc; // Valor total dos documentos
        private Decimal vlDocCanc; // Valor total dos documentos cancelados
        
        //private List<RegistroC381> registroC381List; // BLOCO C - Lista de RegistroC381 (FILHO)
        //private List<RegistroC385> registroC385List; // BLOCO C - Lista de RegistroC385 (FILHO)

        public RegistroC380()
        {
            /*
            registroC381List = new ArrayList<RegistroC381>();
            registroC385List = new ArrayList<RegistroC385>();
             */ 
        }

        /**
         * @return the codMod
         */
        public String getCodMod()
        {
            return codMod;
        }

        /**
         * @param codMod the codMod to set
         */
        public void setCodMod(String codMod)
        {
            this.codMod = codMod;
        }

        /**
        * @return the dtDocIni
        */
        public DateTime getDtDocIni()
        {
            return dtDocIni;
        }

        /**
         * @param dtDocIni the dtDocIni to set
         */
        public void setDtDocIni(DateTime dtDocIni)
        {
            this.dtDocIni = dtDocIni;
        }

        /**
        * @return the dtDocFin
        */
        public DateTime getDtDocFin()
        {
            return dtDocFin;
        }

        /**
         * @param dtDocFin the dtDocFin to set
         */
        public void setDtDocFin(DateTime dtDocFin)
        {
            this.dtDocFin = dtDocFin;
        }  

        /**
         * @return the numDocIni
         */
        public String getNumDocIni()
        {
            return numDocIni;
        }

        /**
         * @param numDocIni the numDocIni to set
         */
        public void setNumDocIni(String numDocIni)
        {
            this.numDocIni = numDocIni;
        }

        /**
         * @return the numDocFin
         */
        public String getNumDocFin()
        {
            return numDocFin;
        }

        /**
         * @param numDocFin the numDocFin to set
         */
        public void setNumDocFin(String numDocFin)
        {
            this.numDocFin = numDocFin;
        }

        /**
         * @return the vlDoc
         */
        public Decimal getVlDoc()
        {
            return vlDoc;
        }

        /**
         * @param vlDoc the vlDoc to set
         */
        public void setVlDoc(Decimal vlDoc)
        {
            this.vlDoc = vlDoc;
        }

        /**
         * @return the vlDocCanc
         */
        public Decimal getvlDocCanc()
        {
            return vlDocCanc;
        }

        /**
         * @param vlDocCanc the vlDocCanc to set
         */
        public void setvlDocCanc(Decimal vlDocCanc)
        {
            this.vlDocCanc = vlDocCanc;
        }

    }
}