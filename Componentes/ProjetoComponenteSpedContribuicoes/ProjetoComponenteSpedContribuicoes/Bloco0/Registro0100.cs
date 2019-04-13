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


    public class Registro0100
    {

        private String nome; // Nome do contabilista/escritório
        private String cpf; // Número de inscrição no CPF
        private String crc; // Número de inscrição no Conselho Regional
        private String cnpj; // CNPJ do escritório de contabilidade, se houver
        private String cep; // Código de Endereçamento Postal
        private String endereco; // Logradouro e endereço do imóvel
        private String num; // Número do imóvel
        private String compl; // Dados complementares do endereço
        private String bairro; // Bairro em que o imóvel está situado
        private String fone; // Número do telefone
        private String fax; // Número do fax
        private String email; // Endereço do correio eletrônico
        private int codMun; // Código do município, conforme tabela IBGE

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
         * @return the crc
         */
        public String getCrc()
        {
            return crc;
        }

        /**
         * @param crc the crc to set
         */
        public void setCrc(String crc)
        {
            this.crc = crc;
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
         * @return the cep
         */
        public String getCep()
        {
            return cep;
        }

        /**
         * @param cep the cep to set
         */
        public void setCep(String cep)
        {
            this.cep = cep;
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

        /**
         * @return the fone
         */
        public String getFone()
        {
            return fone;
        }

        /**
         * @param fone the fone to set
         */
        public void setFone(String fone)
        {
            this.fone = fone;
        }

        /**
         * @return the fax
         */
        public String getFax()
        {
            return fax;
        }

        /**
         * @param fax the fax to set
         */
        public void setFax(String fax)
        {
            this.fax = fax;
        }

        /**
         * @return the email
         */
        public String getEmail()
        {
            return email;
        }

        /**
         * @param email the email to set
         */
        public void setEmail(String email)
        {
            this.email = email;
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
    }
}