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

    public class BlocoM
    {

        private RegistroM001 registroM001;
        private RegistroM990 registroM990;
        private SpedUtil util;

        public BlocoM(SpedUtil spedUtil)
        {
            registroM001 = new RegistroM001();
            registroM001.setIndMov(0);

            registroM990 = new RegistroM990();
            registroM990.setQtdLinM(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroM990().setQtdLinM(0);
        }

        public String writeRegistroM001()
        {
            getRegistroM990().setQtdLinM(getRegistroM990().getQtdLinM() + 1);

            String registro = "";
            registro += getUtil().fill("M001")
                    + getUtil().fill(getRegistroM001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistroM990()
        {
            return getUtil().fill("M990")
                    + getUtil().fill(getRegistroM990().getQtdLinM())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroM001
         */
        public RegistroM001 getRegistroM001()
        {
            return registroM001;
        }

        /**
         * @param registroM001 the registroM001 to set
         */
        public void setRegistroM001(RegistroM001 registroM001)
        {
            this.registroM001 = registroM001;
        }

        /**
         * @return the registroM990
         */
        public RegistroM990 getRegistroM990()
        {
            return registroM990;
        }

        /**
         * @param registroM990 the registroM990 to set
         */
        public void setRegistroM990(RegistroM990 registroM990)
        {
            this.registroM990 = registroM990;
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