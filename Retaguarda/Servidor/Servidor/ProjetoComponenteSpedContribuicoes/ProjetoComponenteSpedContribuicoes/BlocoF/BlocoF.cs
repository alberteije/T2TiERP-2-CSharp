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

    public class BlocoF
    {

        private RegistroF001 registroF001;
        private RegistroF990 registroF990;
        private SpedUtil util;

        public BlocoF(SpedUtil spedUtil)
        {
            registroF001 = new RegistroF001();
            registroF001.setIndMov(0);

            registroF990 = new RegistroF990();
            registroF990.setQtdLinF(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroF990().setQtdLinF(0);
        }

        public String writeRegistroF001()
        {
            getRegistroF990().setQtdLinF(getRegistroF990().getQtdLinF() + 1);

            String registro = "";
            registro += getUtil().fill("F001")
                    + getUtil().fill(getRegistroF001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistroF990()
        {
            return getUtil().fill("F990")
                    + getUtil().fill(getRegistroF990().getQtdLinF())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroF001
         */
        public RegistroF001 getRegistroF001()
        {
            return registroF001;
        }

        /**
         * @param registroF001 the registroF001 to set
         */
        public void setRegistroF001(RegistroF001 registroF001)
        {
            this.registroF001 = registroF001;
        }

        /**
         * @return the registroF990
         */
        public RegistroF990 getRegistroF990()
        {
            return registroF990;
        }

        /**
         * @param registroF990 the registroF990 to set
         */
        public void setRegistroF990(RegistroF990 registroF990)
        {
            this.registroF990 = registroF990;
        }

        /**
         * @return the util
         */
        public SpedUtil getUtil()
        {
            return util;
        }

        /**
         * @param util the util to set
         */
        public void setUtil(SpedUtil util)
        {
            this.util = util;
        }

    }
}