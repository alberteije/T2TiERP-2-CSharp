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

    public class Bloco1
    {

        private Registro1001 registro1001;
        private Registro1990 registro1990;
        private SpedUtil util;

        public Bloco1(SpedUtil spedUtil)
        {
            registro1001 = new Registro1001();
            registro1001.setIndMov(0);

            registro1990 = new Registro1990();
            registro1990.setQtdLin1(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistro1990().setQtdLin1(0);
        }

        public String writeRegistro1001()
        {
            getRegistro1990().setQtdLin1(getRegistro1990().getQtdLin1() + 1);

            String registro = "";
            registro += getUtil().fill("1001")
                    + getUtil().fill(getRegistro1001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            return registro;
        }

        public String writeRegistro1990()
        {
            return getUtil().fill("1990")
                    + getUtil().fill(getRegistro1990().getQtdLin1())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registro1001
         */
        public Registro1001 getRegistro1001()
        {
            return registro1001;
        }

        /**
         * @param registro1001 the registro1001 to set
         */
        public void setRegistro1001(Registro1001 registro1001)
        {
            this.registro1001 = registro1001;
        }

        /**
         * @return the registro1990
         */
        public Registro1990 getRegistro1990()
        {
            return registro1990;
        }

        /**
         * @param registro1990 the registro1990 to set
         */
        public void setRegistro1990(Registro1990 registro1990)
        {
            this.registro1990 = registro1990;
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