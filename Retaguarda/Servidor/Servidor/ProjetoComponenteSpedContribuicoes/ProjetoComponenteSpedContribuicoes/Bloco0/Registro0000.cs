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

    public class Registro0000
    {

        private String codVer; // Código da versão do leiaute - 100, 101, 102
        private String codFin; // Código da finalidade do arquivo - 0 - Remessa do arquivo original / 1 - Remessa do arquivo substituto.
        private DateTime dtIni; // Data inicial das informações contidas no arquivo
        private DateTime dtFin; // Data final das informações contidas no arquivo
        private String nome; // Nome empresarial do contribuinte
        private String cnpj; // Número de inscrição do contribuinte
        private String cpf; // Número de inscrição do contribuinte
        private String uf; // Sigla da unidade da federação
        private String ie; // Inscrição Estadual do contribuinte
        private int codMun; // Código do município do domicílio fiscal
        private String im; // Inscrição Municipal do contribuinte
        private String suframa; // Número de inscrição do contribuinte
        private String indPerfil; // Perfil de apresentação do arquivo - fiscal A - Perfil A / B - Perfil B / C - Perfil C
        private String indAtiv; // Indicador de tipo de atividade - 0 - Industrial ou equiparado a industrial / 1 - Outros.

        /**
         * @return the codVer
         */
        public String getCodVer()
        {
            return codVer;
        }

        /**
         * @param codVer the codVer to set
         */
        public void setCodVer(String codVer)
        {
            this.codVer = codVer;
        }

        /**
         * @return the codFin
         */
        public String getCodFin()
        {
            return codFin;
        }

        /**
         * @param codFin the codFin to set
         */
        public void setCodFin(String codFin)
        {
            this.codFin = codFin;
        }

        /**
         * @return the dtIni
         */
        public DateTime getDtIni()
        {
            return dtIni;
        }

        /**
         * @param dtIni the dtIni to set
         */
        public void setDtIni(DateTime dtIni)
        {
            this.dtIni = dtIni;
        }

        /**
         * @return the dtFin
         */
        public DateTime getDtFin()
        {
            return dtFin;
        }

        /**
         * @param dtFin the dtFin to set
         */
        public void setDtFin(DateTime dtFin)
        {
            this.dtFin = dtFin;
        }

        /**
         * @return the nome
         */
        public String getNome()
        {
            return nome;
        }

        /**
         * @param nome the nome to set
         */
        public void setNome(String nome)
        {
            this.nome = nome;
        }

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
         * @return the cpf
         */
        public String getCpf()
        {
            return cpf;
        }

        /**
         * @param cpf the cpf to set
         */
        public void setCpf(String cpf)
        {
            this.cpf = cpf;
        }

        /**
         * @return the uf
         */
        public String getUf()
        {
            return uf;
        }

        /**
         * @param uf the uf to set
         */
        public void setUf(String uf)
        {
            this.uf = uf;
        }

        /**
         * @return the ie
         */
        public String getIe()
        {
            return ie;
        }

        /**
         * @param ie the ie to set
         */
        public void setIe(String ie)
        {
            this.ie = ie;
        }

        /**
         * @return the codMun
         */
        public int getCodMun()
        {
            return codMun;
        }

        /**
         * @param codMun the codMun to set
         */
        public void setCodMun(int codMun)
        {
            this.codMun = codMun;
        }

        /**
         * @return the im
         */
        public String getIm()
        {
            return im;
        }

        /**
         * @param im the im to set
         */
        public void setIm(String im)
        {
            this.im = im;
        }

        /**
         * @return the suframa
         */
        public String getSuframa()
        {
            return suframa;
        }

        /**
         * @param suframa the suframa to set
         */
        public void setSuframa(String suframa)
        {
            this.suframa = suframa;
        }

        /**
         * @return the indPerfil
         */
        public String getIndPerfil()
        {
            return indPerfil;
        }

        /**
         * @param indPerfil the indPerfil to set
         */
        public void setIndPerfil(String indPerfil)
        {
            this.indPerfil = indPerfil;
        }

        /**
         * @return the indAtiv
         */
        public String getIndAtiv()
        {
            return indAtiv;
        }

        /**
         * @param indAtiv the indAtiv to set
         */
        public void setIndAtiv(String indAtiv)
        {
            this.indAtiv = indAtiv;
        }
    }
}