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

    public class BlocoD
    {

        private RegistroD001 registroD001;
        private RegistroD990 registroD990;
        private SpedUtil util;

        public BlocoD(SpedUtil spedUtil)
        {
            registroD001 = new RegistroD001();
            registroD001.setIndMov(0);

            registroD990 = new RegistroD990();
            registroD990.setQtdLinD(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroD990().setQtdLinD(0);
        }

        public String writeRegistroD001()
        {
            getRegistroD990().setQtdLinD(getRegistroD990().getQtdLinD() + 1);

            String registro = "";
            registro += getUtil().fill("D001")
                    + getUtil().fill(getRegistroD001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistroD990()
        {
            return getUtil().fill("D990")
                    + getUtil().fill(getRegistroD990().getQtdLinD())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroD001
         */
        public RegistroD001 getRegistroD001()
        {
            return registroD001;
        }

        /**
         * @param registroD001 the registroD001 to set
         */
        public void setRegistroD001(RegistroD001 registroD001)
        {
            this.registroD001 = registroD001;
        }

        /**
         * @return the registroD990
         */
        public RegistroD990 getRegistroD990()
        {
            return registroD990;
        }

        /**
         * @param registroD990 the registroD990 to set
         */
        public void setRegistroD990(RegistroD990 registroD990)
        {
            this.registroD990 = registroD990;
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