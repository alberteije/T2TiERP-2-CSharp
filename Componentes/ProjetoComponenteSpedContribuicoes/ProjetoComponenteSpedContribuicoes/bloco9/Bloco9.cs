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

    public class Bloco9
    {

        private Registro9001 registro9001;
        private List<Registro9900> listaRegistro9900;
        private Registro9990 registro9990;
        private Registro9999 registro9999;
        private SpedUtil util;

        public Bloco9(SpedUtil spedUtil)
        {
            registro9001 = new Registro9001();
            registro9001.setIndMov(1);
            listaRegistro9900 = new List<Registro9900>();
            registro9990 = new Registro9990();
            registro9999 = new Registro9999();

            registro9990.setQtdLin9(0);

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            listaRegistro9900.Clear();

            registro9990.setQtdLin9(0);
        }

        public String writeRegistro9001()
        {
            getRegistro9990().setQtdLin9(getRegistro9990().getQtdLin9() + 1);
            return util.fill("9001") +
                    util.fill(getRegistro9001().getIndMov()) +
                    util.getDelimitador() +
                    util.getCrlf();
        }

        public String writeRegistro9900()
        {
            String registro = "";
            for (int i = 0; i < getListaRegistro9900().Count; i++)
            {
                registro += util.fill("9900") +
                        util.fill(getListaRegistro9900()[i].getRegBlc()) +
                        util.fill(getListaRegistro9900()[i].getQtdRegBlc()) +
                        util.getDelimitador() +
                        util.getCrlf();
            }
            getRegistro9990().setQtdLin9(getRegistro9990().getQtdLin9() + getListaRegistro9900().Count + 2);
            return registro;
        }

        public String writeRegistro9990()
        {
            return util.fill("9990") +
                    util.fill(getRegistro9990().getQtdLin9()) +
                    util.getDelimitador() +
                    util.getCrlf();
        }

        public String writeRegistro9999()
        {
            return util.fill("9999") +
                    util.fill(getRegistro9999().getQtdLin()) +
                    util.getDelimitador() +
                    util.getCrlf();
        }

        /**
         * @return the registro9001
         */
        public Registro9001 getRegistro9001()
        {
            return registro9001;
        }

        /**
         * @return the listaRegistro9900
         */
        public List<Registro9900> getListaRegistro9900()
        {
            return listaRegistro9900;
        }

        /**
         * @return the registro9990
         */
        public Registro9990 getRegistro9990()
        {
            return registro9990;
        }

        /**
         * @return the registro9999
         */
        public Registro9999 getRegistro9999()
        {
            return registro9999;
        }
    }
}