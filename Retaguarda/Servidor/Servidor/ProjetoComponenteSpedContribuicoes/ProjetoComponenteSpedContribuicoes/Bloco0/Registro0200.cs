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

    public class Registro0200
    {

        private String codItem; // Código do item
        private String descrItem; // Descrição do item
        private String codBarra; // Código de barra do produto, se houver
        private String codAntItem; // Código anterior do item (ultima apresentado)
        private String unidInv; // Unidade de medida do estoque
        private String tipoItem; // Tipo do item - Atividades Industriais, Comerciais e Serviços -  00 - Mercadoria para Revenda, 01 - Matéria-Prima,  02 - Embalagem, 03 - Produto em Processo, 04 - Produto Acabado, 05 - Subproduto, 06 - Produto Intermediário, 07 - Material de Uso e Consumo, 08 - Ativo Imobilizado, 09 - Serviços, 10 - Outros insumos, 99 - Outras
        private String codNcm; // Código da Nomenclatura Comum do Mercosul
        private String exIpi; // Código EX, conforme a TIPI
        private String codGen; // Código gênero item, tabela indicada item 4.2.1
        private String codLst; // Código serviço Anexo I - Lei nº116/03
        private decimal aliqIcms; // Alíquota ICMS aplicável (operações internas)
        private List<Registro0205> registro0205List; // BLOCO 0 - Lista de Registro0205 (FILHO)

        public Registro0200()
        {
            registro0205List = new List<Registro0205>();
        }

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
         * @return the descrItem
         */
        public String getDescrItem()
        {
            return descrItem;
        }

        /**
         * @param descrItem the descrItem to set
         */
        public void setDescrItem(String descrItem)
        {
            this.descrItem = descrItem;
        }

        /**
         * @return the codBarra
         */
        public String getCodBarra()
        {
            return codBarra;
        }

        /**
         * @param codBarra the codBarra to set
         */
        public void setCodBarra(String codBarra)
        {
            this.codBarra = codBarra;
        }

        /**
         * @return the codAntItem
         */
        public String getCodAntItem()
        {
            return codAntItem;
        }

        /**
         * @param codAntItem the codAntItem to set
         */
        public void setCodAntItem(String codAntItem)
        {
            this.codAntItem = codAntItem;
        }

        /**
         * @return the unidInv
         */
        public String getUnidInv()
        {
            return unidInv;
        }

        /**
         * @param unidInv the unidInv to set
         */
        public void setUnidInv(String unidInv)
        {
            this.unidInv = unidInv;
        }

        /**
         * @return the tipoItem
         */
        public String getTipoItem()
        {
            return tipoItem;
        }

        /**
         * @param tipoItem the tipoItem to set
         */
        public void setTipoItem(String tipoItem)
        {
            this.tipoItem = tipoItem;
        }

        /**
         * @return the codNcm
         */
        public String getCodNcm()
        {
            return codNcm;
        }

        /**
         * @param codNcm the codNcm to set
         */
        public void setCodNcm(String codNcm)
        {
            this.codNcm = codNcm;
        }

        /**
         * @return the exIpi
         */
        public String getExIpi()
        {
            return exIpi;
        }

        /**
         * @param exIpi the exIpi to set
         */
        public void setExIpi(String exIpi)
        {
            this.exIpi = exIpi;
        }

        /**
         * @return the codGen
         */
        public String getCodGen()
        {
            return codGen;
        }

        /**
         * @param codGen the codGen to set
         */
        public void setCodGen(String codGen)
        {
            this.codGen = codGen;
        }

        /**
         * @return the codLst
         */
        public String getCodLst()
        {
            return codLst;
        }

        /**
         * @param codLst the codLst to set
         */
        public void setCodLst(String codLst)
        {
            this.codLst = codLst;
        }

        /**
         * @return the aliqIcms
         */
        public decimal getAliqIcms()
        {
            return aliqIcms;
        }

        /**
         * @param aliqIcms the aliqIcms to set
         */
        public void setAliqIcms(decimal aliqIcms)
        {
            this.aliqIcms = aliqIcms;
        }

        /**
         * @return the registro0205List
         */
        public List<Registro0205> getRegistro0205List()
        {
            return registro0205List;
        }

        /**
         * @param registro0205List the registro0205List to set
         */
        public void setRegistro0205List(List<Registro0205> registro0205List)
        {
            this.registro0205List = registro0205List;
        }

    }
}