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

    public class Registro0205
    {

        private String descrAntItem; // Descrição anterior do item
        private DateTime dtIni; // Data inicial de utilização do código
        private DateTime dtFin; // Data final de utilização do código
        private String codAntItem; // Código anterior do item com relação à última informação apresentada.

        /**
         * @return the descrAntItem
         */
        public String getDescrAntItem()
        {
            return descrAntItem;
        }

        /**
         * @param descrAntItem the descrAntItem to set
         */
        public void setDescrAntItem(String descrAntItem)
        {
            this.descrAntItem = descrAntItem;
        }

        /**
         * @return the dtIni
         */
        public DateTime getDtIni()
        {
            return dtIni;
        }

        /**
         * @param dtIni the dtIni to set
         */
        public void setDtIni(DateTime dtIni)
        {
            this.dtIni = dtIni;
        }

        /**
         * @return the dtFin
         */
        public DateTime getDtFin()
        {
            return dtFin;
        }

        /**
         * @param dtFin the dtFin to set
         */
        public void setDtFin(DateTime dtFin)
        {
            this.dtFin = dtFin;
        }

        /**
         * @return the codAntItem
         */
        public String getCodAntItem()
        {
            return codAntItem;
        }

        /**
         * @param codAntItem the codAntItem to set
         */
        public void setCodAntItem(String codAntItem)
        {
            this.codAntItem = codAntItem;
        }
    }
}