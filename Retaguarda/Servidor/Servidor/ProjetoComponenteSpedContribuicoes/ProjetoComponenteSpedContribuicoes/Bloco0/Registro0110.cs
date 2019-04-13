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

namespace ComponenteSpedContribuicoes
{

    public class Registro0110
    {

        private String codIncTrib; // Código indicador da incidência tributária no período: 1 – Escrituração de operações com incidência exclusivamente no regime não-cumulativo; 2 – Escrituração de operações com incidência exclusivamente no regime cumulativo; 3 – Escrituração de operações com incidência nos regimes não-cumulativo e cumulativo. 
        private String indAproCred; // Código indicador de método de apropriação de créditos comuns, no caso de incidência no regime não- cumulativo (COD_INC_TRIB = 1 ou 3): 1 – Método de Apropriação Direta; 2 – Método de Rateio Proporcional (Receita Bruta) 
        private String codTipoCont; // Código indicador do Tipo de Contribuição Apurada no Período 1 – Apuração da Contribuição Exclusivamente a Alíquota Básica 2 – Apuração da Contribuição a Alíquotas Específicas (Diferenciadas e/ou por Unidade de Medida de Produto)
        private String indRegCum; // Código indicador do critério de escrituração e apuração adotado, no caso de incidência exclusivamente no regime cumulativo (COD_INC_TRIB = 2), pela pessoa jurídica submetida ao regime de tributação com base no lucro presumido: 1 – Regime de Caixa – Escrituração consolidada (Registro F500); 2 – Regime de Competência - Escrituração consolidada (Registro F550); 9 – Regime de Competência - Escrituração detalhada, com base nos registros dos Blocos “A”, “C”, “D” e “F”.

        /**
         * @return the codIncTrib
         */
        public String getCodIncTrib()
        {
            return codIncTrib;
        }

        /**
         * @param fantasia the codIncTrib to set
         */
        public void setCodIncTrib(String codIncTrib)
        {
            this.codIncTrib = codIncTrib;
        }

        /**
         * @return the indAproCred
         */
        public String getIndAproCred()
        {
            return indAproCred;
        }

        /**
         * @param cep the indAproCred to set
         */
        public void setIndAproCred(String indAproCred)
        {
            this.indAproCred = indAproCred;
        }

        /**
         * @return the codTipoCont
         */
        public String getCodTipoCont()
        {
            return codTipoCont;
        }

        /**
         * @param endereco the codTipoCont to set
         */
        public void setCodTipoCont(String codTipoCont)
        {
            this.codTipoCont = codTipoCont;
        }

        /**
         * @return the indRegCum
         */
        public String getIndRegCum()
        {
            return indRegCum;
        }

        /**
         * @param num the indRegCum to set
         */
        public void setIndRegCum(String indRegCum)
        {
            this.indRegCum = indRegCum;
        }

    }
}