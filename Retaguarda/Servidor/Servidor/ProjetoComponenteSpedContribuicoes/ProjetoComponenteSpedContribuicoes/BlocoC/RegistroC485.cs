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

    public class RegistroC485
    {

        private String codItem; // Código do item (campo 02 do Registro 0200)
        private Decimal qtd; // Quantidade acumulada do item
        private String unid; // Unidade do item (Campo 02 do registro 0190)
        private Decimal vlItem; // Valor acumulado do item
        private Decimal vlPis; // Valor do PIS
        private Decimal vlCofins; // Valor da COFINS

        /**
         * @return the codItem
         */
        public String getCodItem()
        {
            return codItem;
        }

        /**
         * @param codItem the codItem to set
         */
        public void setCodItem(String codItem)
        {
            this.codItem = codItem;
        }

        /**
         * @return the qtd
         */
        public Decimal getQtd()
        {
            return qtd;
        }

        /**
         * @param qtd the qtd to set
         */
        public void setQtd(Decimal qtd)
        {
            this.qtd = qtd;
        }

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
         * @return the vlItem
         */
        public Decimal getVlItem()
        {
            return vlItem;
        }

        /**
         * @param vlItem the vlItem to set
         */
        public void setVlItem(Decimal vlItem)
        {
            this.vlItem = vlItem;
        }

        /**
         * @return the vlPis
         */
        public Decimal getVlPis()
        {
            return vlPis;
        }

        /**
         * @param vlPis the vlPis to set
         */
        public void setVlPis(Decimal vlPis)
        {
            this.vlPis = vlPis;
        }

        /**
         * @return the vlCofins
         */
        public Decimal getVlCofins()
        {
            return vlCofins;
        }

        /**
         * @param vlCofins the vlCofins to set
         */
        public void setVlCofins(Decimal vlCofins)
        {
            this.vlCofins = vlCofins;
        }
    }
}