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

    public class RegistroC010
    {

        private String cnpj; // Número de inscrição do estabelecimento no CNPJ. 
        private String indEscri; // Indicador da apuração das contribuições e créditos, na escrituração das operações por NF-e e ECF, no período: 1 – Apuração com base nos registros de consolidação das operações por NF-e (C180 e C190) e por ECF (C490); 2 – Apuração com base no registro individualizado de NF-e (C100 e C170) e de ECF (C400) 

         
        /**
         * @return the cnpj
         */
        public String getCnpj()
        {
            return cnpj;
        }

        /**
         * @param cnpj the cnpj to set
         */
        public void setCnpj(String cnpj)
        {
            this.cnpj = cnpj;       
        }

        /**
         * @return the indEscri
         */
        public String getIndEscri()
        {
            return indEscri;
        }

        /**
         * @param indEscri the indEscri to set
         */
        public void setIndEscri(String indEscri)
        {
            this.indEscri = indEscri;
        }

   }
}