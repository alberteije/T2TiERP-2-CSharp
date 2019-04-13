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

    public class BlocoI
    {

        private RegistroI001 registroI001;
        private RegistroI990 registroI990;
        private SpedUtil util;

        public BlocoI(SpedUtil spedUtil)
        {
            registroI001 = new RegistroI001();
            registroI001.setIndMov(0);

            registroI990 = new RegistroI990();
            registroI990.setQtdLinI(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroI990().setQtdLinI(0);
        }

        public String writeRegistroI001()
        {
            getRegistroI990().setQtdLinI(getRegistroI990().getQtdLinI() + 1);

            String registro = "";
            registro += getUtil().fill("I001")
                    + getUtil().fill(getRegistroI001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistroI990()
        {
            return getUtil().fill("I990")
                    + getUtil().fill(getRegistroI990().getQtdLinI())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroI001
         */
        public RegistroI001 getRegistroI001()
        {
            return registroI001;
        }

        /**
         * @param registroI001 the registroI001 to set
         */
        public void setRegistroI001(RegistroI001 registroI001)
        {
            this.registroI001 = registroI001;
        }

        /**
         * @return the registroI990
         */
        public RegistroI990 getRegistroI990()
        {
            return registroI990;
        }

        /**
         * @param registroI990 the registroI990 to set
         */
        public void setRegistroI990(RegistroI990 registroI990)
        {
            this.registroI990 = registroI990;
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