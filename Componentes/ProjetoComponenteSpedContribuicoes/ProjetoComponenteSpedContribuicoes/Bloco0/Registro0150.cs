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

    public class Registro0150
    {

        private String codPart; // Código de identificação do participante
        private String nome; // Nome pessoal ou empresarial
        private String codPais; // Código do país do participante
        private String cnpj; // CNPJ do participante
        private String cpf; // CPF do participante na unidade da federação do destinatário
        private String ie; // Inscrição Estadual do participante
        private int codMun; // Código do município
        private String suframa; // Número de inscrição na Suframa
        private String endereco; // Logradouro e endereço do imóvel
        private String num; // Número do imóvel
        private String compl; // Dados complementares do endereço
        private String bairro; // Bairro em que o imóvel está situado

        /**
         * @return the codPart
         */
        public String getCodPart()
        {
            return codPart;
        }

        /**
         * @param codPart the codPart to set
         */
        public void setCodPart(String codPart)
        {
            this.codPart = codPart;
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
         * @return the codPais
         */
        public String getCodPais()
        {
            return codPais;
        }

        /**
         * @param codPais the codPais to set
         */
        public void setCodPais(String codPais)
        {
            this.codPais = codPais;
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
         * @return the endereco
         */
        public String getEndereco()
        {
            return endereco;
        }

        /**
         * @param endereco the endereco to set
         */
        public void setEndereco(String endereco)
        {
            this.endereco = endereco;
        }

        /**
         * @return the num
         */
        public String getNum()
        {
            return num;
        }

        /**
         * @param num the num to set
         */
        public void setNum(String num)
        {
            this.num = num;
        }

        /**
         * @return the compl
         */
        public String getCompl()
        {
            return compl;
        }

        /**
         * @param compl the compl to set
         */
        public void setCompl(String compl)
        {
            this.compl = compl;
        }

        /**
         * @return the bairro
         */
        public String getBairro()
        {
            return bairro;
        }

        /**
         * @param bairro the bairro to set
         */
        public void setBairro(String bairro)
        {
            this.bairro = bairro;
        }

    }
}