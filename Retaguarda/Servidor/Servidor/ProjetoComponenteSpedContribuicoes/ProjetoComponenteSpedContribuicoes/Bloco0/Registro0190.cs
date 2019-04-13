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

    public class Registro0190
    {

        private String unid; // Código da unidade de medida
        private String descr; // Descrição da unidade de medida

        /**
         * @return the unid
         */
        public String getUnid()
        {
            return unid;
        }

        /**
         * @param unid the unid to set
         */
        public void setUnid(String unid)
        {
            this.unid = unid;
        }

        /**
         * @return the descr
         */
        public String getDescr()
        {
            return descr;
        }

        /**
         * @param descr the descr to set
         */
        public void setDescr(String descr)
        {
            this.descr = descr;
        }
    }
}