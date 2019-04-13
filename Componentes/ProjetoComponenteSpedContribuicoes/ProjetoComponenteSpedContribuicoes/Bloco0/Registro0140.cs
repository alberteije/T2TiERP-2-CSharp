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

    public class Registro0140
    {

        private String codEst; // Código de identificação do estabelecimento 
        private String nome; // Nome empresarial do estabelecimento
        private String cnpj; // Número de inscrição do estabelecimento no CNPJ. 
        private String uf; // Sigla da unidade da federação do estabelecimento.
        private String ie; // Inscrição Estadual do estabelecimento, se contribuinte de ICMS.
        private int codMun; // Código do município do domicílio fiscal do estabelecimento, conforme a tabela IBGE 
        private String im; // Inscrição Municipal do estabelecimento, se contribuinte do ISS.
        private String suframa; // Inscrição do estabelecimento na Suframa

        private List<Registro0150> registro0150List; // BLOCO 0 - Lista de Registro0150 (FILHO)
        private List<Registro0190> registro0190List; // BLOCO 0 - Lista de Registro0190 (FILHO)
        private List<Registro0200> registro0200List; // BLOCO 0 - Lista de Registro0200 (FILHO)

        public Registro0140() {
            registro0150List = new List<Registro0150>();
            registro0190List = new List<Registro0190>();
            registro0200List = new List<Registro0200>();
        }

        public String getCodEst()
        {
            return codEst;
        }

        public void setCodEst(String codEst)
        {
            this.codEst = codEst;
        }

        public String getNome()
        {
            return nome;
        }

        public void setNome(String nome)
        {
            this.nome = nome;
        }

        public String getCnpj()
        {
            return cnpj;
        }

        public void setCnpj(String cnpj)
        {
            this.cnpj = cnpj;
        }

        public String getUf()
        {
            return uf;
        }

        public void setUf(String uf)
        {
            this.uf = uf;
        }

        public String getIe()
        {
            return ie;
        }

        public void setIe(String ie)
        {
            this.ie = ie;
        }

        public int getCodMun()
        {
            return codMun;
        }

        public void setCodMun(int codMun)
        {
            this.codMun = codMun;
        }

        public String getIm()
        {
            return im;
        }

        public void setIm(String im)
        {
            this.im = im;
        }

        public String getSuframa()
        {
            return suframa;
        }

        public void setSuframa(String suframa)
        {
            this.suframa = suframa;
        }

        /**
         * @return the registro0150List
         */
        public List<Registro0150> getRegistro0150List()
        {
            return registro0150List;
        }

        /**
         * @param registro0150List the registro0150List to set
         */
        public void setRegistro0150List(List<Registro0150> registro0150List)
        {
            this.registro0150List = registro0150List;
        }

        /**
         * @return the registro0190List
         */
        public List<Registro0190> getRegistro0190List()
        {
            return registro0190List;
        }

        /**
         * @param registro0190List the registro0190List to set
         */
        public void setRegistro0190List(List<Registro0190> registro0190List)
        {
            this.registro0190List = registro0190List;
        }

        /**
         * @return the registro0200List
         */
        public List<Registro0200> getRegistro0200List()
        {
            return registro0200List;
        }

        /**
         * @param registro0200List the registro0200List to set
         */
        public void setRegistro0200List(List<Registro0200> registro0200List)
        {
            this.registro0200List = registro0200List;
        }

    }
}