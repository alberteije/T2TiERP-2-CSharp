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

    public class Registro0600
    {

        private DateTime dtAlt; // Data da inclusão/alteração
        private String codCcus; // Código do centro de custos.
        private String ccus; // Nome do centro de custos.

        /**
         * @return the dtAlt
         */
        public DateTime getDtAlt()
        {
            return dtAlt;
        }

        /**
         * @param dtAlt the dtAlt to set
         */
        public void setDtAlt(DateTime dtAlt)
        {
            this.dtAlt = dtAlt;
        }

        /**
         * @return the codCcus
         */
        public String getCodCcus()
        {
            return codCcus;
        }

        /**
         * @param codCcus the codCcus to set
         */
        public void setCodCcus(String codCcus)
        {
            this.codCcus = codCcus;
        }

        /**
         * @return the ccus
         */
        public String getCcus()
        {
            return ccus;
        }

        /**
         * @param ccus the ccus to set
         */
        public void setCcus(String ccus)
        {
            this.ccus = ccus;
        }
    }
}