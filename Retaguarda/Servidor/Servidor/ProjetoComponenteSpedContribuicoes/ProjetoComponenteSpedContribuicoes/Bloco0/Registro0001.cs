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

    public class Registro0001
    {

        private int indMov; // Indicador de movimento: 0- Bloco com dados informados, 1- Bloco sem dados informados.

        private Registro0100 registro0100; // BLOCO 0 - Registro0100 (FILHO)
        private Registro0110 registro0110; // BLOCO 0 - Registro0100 (FILHO)
        private Registro0140 registro0140; // BLOCO 0 - Registro0100 (FILHO)
        private List<Registro0400> registro0400List; // BLOCO 0 - Lista de Registro0400 (FILHO)
        private List<Registro0450> registro0450List; // BLOCO 0 - Lista de Registro0450 (FILHO)
        private List<Registro0500> registro0500List; // BLOCO 0 - Lista de Registro0500 (FILHO)
        private List<Registro0600> registro0600List; // BLOCO 0 - Lista de Registro0600 (FILHO)

        public Registro0001()
        {
            registro0100 = new Registro0100();
            registro0110 = new Registro0110();
            registro0140 = new Registro0140();
            registro0400List = new List<Registro0400>();
            registro0450List = new List<Registro0450>();
            registro0500List = new List<Registro0500>();
            registro0600List = new List<Registro0600>();
        }

        /**
         * @return the indMov
         */
        public int getIndMov()
        {
            return indMov;
        }

        /**
         * @param indMov the indMov to set
         */
        public void setIndMov(int indMov)
        {
            this.indMov = indMov;
        }

        /**
         * @return the registro0100
         */
        public Registro0100 getRegistro0100()
        {
            return registro0100;
        }

        /**
         * @param registro0100 the registro0100 to set
         */
        public void setRegistro0100(Registro0100 registro0100)
        {
            this.registro0100 = registro0100;
        }

        /**
         * @return the registro0110
         */
        public Registro0110 getRegistro0110()
        {
            return registro0110;
        }

        /**
         * @param registro0110 the registro0110 to set
         */
        public void setRegistro0110(Registro0110 registro0110)
        {
            this.registro0110 = registro0110;
        }

        /**
        * @return the registro0140
        */
        public Registro0140 getRegistro0140()
        {
            return registro0140;
        }

        /**
         * @param registro0140 the registro0140 to set
         */
        public void setRegistro0140(Registro0140 registro0140)
        {
            this.registro0140 = registro0140;
        }

   
        /**
         * @return the registro0400List
         */
        public List<Registro0400> getRegistro0400List()
        {
            return registro0400List;
        }

        /**
         * @param registro0400List the registro0400List to set
         */
        public void setRegistro0400List(List<Registro0400> registro0400List)
        {
            this.registro0400List = registro0400List;
        }

        /**
         * @return the registro0450List
         */
        public List<Registro0450> getRegistro0450List()
        {
            return registro0450List;
        }

        /**
         * @param registro0450List the registro0450List to set
         */
        public void setRegistro0450List(List<Registro0450> registro0450List)
        {
            this.registro0450List = registro0450List;
        }

       
        /**
         * @return the registro0500List
         */
        public List<Registro0500> getRegistro0500List()
        {
            return registro0500List;
        }

        /**
         * @param registro0500List the registro0500List to set
         */
        public void setRegistro0500List(List<Registro0500> registro0500List)
        {
            this.registro0500List = registro0500List;
        }

        /**
         * @return the registro0600List
         */
        public List<Registro0600> getRegistro0600List()
        {
            return registro0600List;
        }

        /**
         * @param registro0600List the registro0600List to set
         */
        public void setRegistro0600List(List<Registro0600> registro0600List)
        {
            this.registro0600List = registro0600List;
        }
    }
}