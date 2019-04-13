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

    public class RegistroC400
    {

        private String codMod; // Código do modelo do documento fiscal, conforme a Tabela 4.1.1
        private String ecfMod; // Modelo do equipamento
        private String ecfFab; // Número de série de fabricação do ECF
        private String ecfCx; // Número do caixa atribuído ao ECF
        private List<RegistroC405> registroC405List; // BLOCO C - Lista de RegistroC405 (FILHO)

        public RegistroC400()
        {
            registroC405List = new List<RegistroC405>();
        }

        /**
         * @return the codMod
         */
        public String getCodMod()
        {
            return codMod;
        }

        /**
         * @param codMod the codMod to set
         */
        public void setCodMod(String codMod)
        {
            this.codMod = codMod;
        }

        /**
         * @return the ecfMod
         */
        public String getEcfMod()
        {
            return ecfMod;
        }

        /**
         * @param ecfMod the ecfMod to set
         */
        public void setEcfMod(String ecfMod)
        {
            this.ecfMod = ecfMod;
        }

        /**
         * @return the ecfFab
         */
        public String getEcfFab()
        {
            return ecfFab;
        }

        /**
         * @param ecfFab the ecfFab to set
         */
        public void setEcfFab(String ecfFab)
        {
            this.ecfFab = ecfFab;
        }

        /**
         * @return the ecfCx
         */
        public String getEcfCx()
        {
            return ecfCx;
        }

        /**
         * @param ecfCx the ecfCx to set
         */
        public void setEcfCx(String ecfCx)
        {
            this.ecfCx = ecfCx;
        }

        /**
         * @return the registroC405List
         */
        public List<RegistroC405> getRegistroC405List()
        {
            return registroC405List;
        }

        /**
         * @param registroC405List the registroC405List to set
         */
        public void setRegistroC405List(List<RegistroC405> registroC405List)
        {
            this.registroC405List = registroC405List;
        }
    }
}