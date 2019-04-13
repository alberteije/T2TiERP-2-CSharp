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

    public class Registro0500
    {

        private DateTime dtAlt; // Data da inclusão/alteração
        private String codNatCc; // Código da natureza da conta/grupo de contas
        private String indCta; // Indicador do tipo de conta: S - Sintética ou A – Analítica
        private String nivel; // Nível da conta analítica/grupo de contas
        private String codCta; // Código da conta analítica/grupo de conta
        private String nomeCta; // Nome da conta analítica/grupo de contas

        /**
         * @return the dtAlt
         */
        public DateTime getDtAlt()
        {
            return dtAlt;
        }

        /**
         * @param dtAlt the dtAlt to set
         */
        public void setDtAlt(DateTime dtAlt)
        {
            this.dtAlt = dtAlt;
        }

        /**
         * @return the codNatCc
         */
        public String getCodNatCc()
        {
            return codNatCc;
        }

        /**
         * @param codNatCc the codNatCc to set
         */
        public void setCodNatCc(String codNatCc)
        {
            this.codNatCc = codNatCc;
        }

        /**
         * @return the indCta
         */
        public String getIndCta()
        {
            return indCta;
        }

        /**
         * @param indCta the indCta to set
         */
        public void setIndCta(String indCta)
        {
            this.indCta = indCta;
        }

        /**
         * @return the nivel
         */
        public String getNivel()
        {
            return nivel;
        }

        /**
         * @param nivel the nivel to set
         */
        public void setNivel(String nivel)
        {
            this.nivel = nivel;
        }

        /**
         * @return the codCta
         */
        public String getCodCta()
        {
            return codCta;
        }

        /**
         * @param codCta the codCta to set
         */
        public void setCodCta(String codCta)
        {
            this.codCta = codCta;
        }

        /**
         * @return the nomeCta
         */
        public String getNomeCta()
        {
            return nomeCta;
        }

        /**
         * @param nomeCta the nomeCta to set
         */
        public void setNomeCta(String nomeCta)
        {
            this.nomeCta = nomeCta;
        }
    }
}