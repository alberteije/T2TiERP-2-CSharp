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

    public class BlocoA
    {

        private RegistroA001 registroA001;
        private RegistroA990 registroA990;
        private SpedUtil util;

        public BlocoA(SpedUtil spedUtil)
        {
            registroA001 = new RegistroA001();
            registroA001.setIndMov(0);

            registroA990 = new RegistroA990();
            registroA990.setQtdLinA(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroA990().setQtdLinA(0);
        }

        public String writeRegistroA001()
        {
            getRegistroA990().setQtdLinA(getRegistroA990().getQtdLinA() + 1);

            String registro = "";
            registro += getUtil().fill("A001")
                    + getUtil().fill(getRegistroA001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistroA990()
        {
            return getUtil().fill("A990")
                    + getUtil().fill(getRegistroA990().getQtdLinA())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroA001
         */
        public RegistroA001 getRegistroA001()
        {
            return registroA001;
        }

        /**
         * @param registroA001 the registroA001 to set
         */
        public void setRegistroA001(RegistroA001 registroA001)
        {
            this.registroA001 = registroA001;
        }

        /**
         * @return the registroA990
         */
        public RegistroA990 getRegistroA990()
        {
            return registroA990;
        }

        /**
         * @param registroA990 the registroA990 to set
         */
        public void setRegistroA990(RegistroA990 registroA990)
        {
            this.registroA990 = registroA990;
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