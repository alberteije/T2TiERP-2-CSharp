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

    public class Bloco0
    {

        private Registro0000 registro0000;
        private Registro0001 registro0001;
        private Registro0100 registro0100;
        private Registro0110 registro0110;
        private Registro0140 registro0140;
        private Registro0990 registro0990;
        private int quantidadeRegistros0150;
        private int quantidadeRegistros0190;
        private int quantidadeRegistros0200;
        private int quantidadeRegistros0205;
        private int quantidadeRegistros0400;
        private int quantidadeRegistros0450;
        private int quantidadeRegistros0500;
        private int quantidadeRegistros0600;
        private SpedUtil util;

        public Bloco0(SpedUtil spedUtil)
        {
            registro0000 = new Registro0000();
            registro0100 = new Registro0100();
            registro0110 = new Registro0110();
            registro0140 = new Registro0140();
            registro0001 = new Registro0001();
            
            registro0001.setIndMov(1);

            registro0990 = new Registro0990();

            registro0990.setQtdLin0(0);

            quantidadeRegistros0150 = 0;
            quantidadeRegistros0190 = 0;
            quantidadeRegistros0200 = 0;
            quantidadeRegistros0205 = 0;
            quantidadeRegistros0400 = 0;
            quantidadeRegistros0450 = 0;
            quantidadeRegistros0500 = 0;
            quantidadeRegistros0600 = 0;

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistro0990().setQtdLin0(0);
        }

        public String writeRegistro0000()
        {
            getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);

            return getUtil().fill("0000")
                    + getUtil().fill(getRegistro0000().getCodVer())
                    + getUtil().fill(getRegistro0000().getCodFin())
                    + getUtil().fill(getRegistro0000().getDtIni())
                    + getUtil().fill(getRegistro0000().getDtFin())
                    + getUtil().fill(getRegistro0000().getNome())
                    + getUtil().fill(getRegistro0000().getCnpj())
                    + getUtil().fill(getRegistro0000().getCpf())
                    + getUtil().fill(getRegistro0000().getUf())
                    + getUtil().fill(getRegistro0000().getIe())
                    + getUtil().fill(getRegistro0000().getCodMun())
                    + getUtil().fill(getRegistro0000().getIm())
                    + getUtil().fill(getRegistro0000().getSuframa())
                    + getUtil().fill(getRegistro0000().getIndPerfil())
                    + getUtil().fill(getRegistro0000().getIndAtiv())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        public String writeRegistro0001()
        {
            getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);

            String registro = "";
            registro += getUtil().fill("0001")
                    + getUtil().fill(getRegistro0001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            registro += writeRegistro0100(getRegistro0001().getRegistro0100());
            registro += writeRegistro0110(getRegistro0001().getRegistro0110());
            registro += writeRegistro0140(getRegistro0001().getRegistro0140());
            registro += writeRegistro0400(getRegistro0001().getRegistro0400List());
            registro += writeRegistro0450(getRegistro0001().getRegistro0450List());
            registro += writeRegistro0500(getRegistro0001().getRegistro0500List());
            registro += writeRegistro0600(getRegistro0001().getRegistro0600List());

            return registro;
        }

        public String writeRegistro0100(Registro0100 registro0100)
        {
            getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);

            return getUtil().fill("0100")
                    + getUtil().fill(registro0100.getNome())
                    + getUtil().fill(registro0100.getCpf())
                    + getUtil().fill(registro0100.getCrc())
                    + getUtil().fill(registro0100.getCnpj())
                    + getUtil().fill(registro0100.getCep())
                    + getUtil().fill(registro0100.getEndereco())
                    + getUtil().fill(registro0100.getNum())
                    + getUtil().fill(registro0100.getCompl())
                    + getUtil().fill(registro0100.getBairro())
                    + getUtil().fill(registro0100.getFone())
                    + getUtil().fill(registro0100.getFax())
                    + getUtil().fill(registro0100.getEmail())
                    + getUtil().fill(registro0100.getCodMun())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        public String writeRegistro0110(Registro0110 registro0110)
        {
            getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);

            return getUtil().fill("0110")
                    + getUtil().fill(registro0110.getCodIncTrib())
                    + getUtil().fill(registro0110.getIndAproCred())
                    + getUtil().fill(registro0110.getCodTipoCont())
                    + getUtil().fill(registro0110.getIndRegCum())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        public String writeRegistro0140(Registro0140 registro0140)
        {
            getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);

            String registro = "";
            registro += getUtil().fill("0140")
                    + getUtil().fill(registro0140.getCodEst())
                    + getUtil().fill(registro0140.getNome())
                    + getUtil().fill(registro0140.getCnpj())
                    + getUtil().fill(registro0140.getUf())
                    + getUtil().fill(registro0140.getIe())
                    + getUtil().fill(registro0140.getCodMun())
                    + getUtil().fill(registro0140.getIm())
                    + getUtil().fill(registro0140.getSuframa())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            registro += writeRegistro0150(registro0140.getRegistro0150List());
            registro += writeRegistro0190(registro0140.getRegistro0190List());
            registro += writeRegistro0200(registro0140.getRegistro0200List());

            return registro;
        }

        public String writeRegistro0150(List<Registro0150> listaRegistro0150)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0150.Count; i++)
            {
                registro += getUtil().fill("0150")
                        + getUtil().fill(listaRegistro0150[i].getCodPart())
                        + getUtil().fill(listaRegistro0150[i].getNome())
                        + getUtil().fill(listaRegistro0150[i].getCodPais())
                        + getUtil().fill(listaRegistro0150[i].getCnpj())
                        + getUtil().fill(listaRegistro0150[i].getCpf())
                        + getUtil().fill(listaRegistro0150[i].getIe())
                        + getUtil().fill(listaRegistro0150[i].getCodMun())
                        + getUtil().fill(listaRegistro0150[i].getSuframa())
                        + getUtil().fill(listaRegistro0150[i].getEndereco())
                        + getUtil().fill(listaRegistro0150[i].getNum())
                        + getUtil().fill(listaRegistro0150[i].getCompl())
                        + getUtil().fill(listaRegistro0150[i].getBairro())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0150((int)(getQuantidadeRegistros0150() + 1));
            }
            return registro;
        }

        public String writeRegistro0190(List<Registro0190> listaRegistro0190)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0190.Count; i++)
            {
                registro += getUtil().fill("0190")
                        + getUtil().fill(listaRegistro0190[i].getUnid())
                        + getUtil().fill(listaRegistro0190[i].getDescr())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0190((int)(getQuantidadeRegistros0190() + 1));
            }
            return registro;
        }

        public String writeRegistro0200(List<Registro0200> listaRegistro0200)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0200.Count; i++)
            {
                registro += getUtil().fill("0200")
                        + getUtil().fill(listaRegistro0200[i].getCodItem())
                        + getUtil().fill(listaRegistro0200[i].getDescrItem())
                        + getUtil().fill(listaRegistro0200[i].getCodBarra())
                        + getUtil().fill(listaRegistro0200[i].getCodAntItem())
                        + getUtil().fill(listaRegistro0200[i].getUnidInv())
                        + getUtil().fill(listaRegistro0200[i].getTipoItem())
                        + getUtil().fill(listaRegistro0200[i].getCodNcm())
                        + getUtil().fill(listaRegistro0200[i].getExIpi())
                        + getUtil().fill(listaRegistro0200[i].getCodGen())
                        + getUtil().fill(listaRegistro0200[i].getCodLst())
                        + getUtil().fill(listaRegistro0200[i].getAliqIcms())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                registro += writeRegistro0205(listaRegistro0200[i].getRegistro0205List());

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0200((int)(getQuantidadeRegistros0200() + 1));
            }
            return registro;
        }

        public String writeRegistro0205(List<Registro0205> listaRegistro0205)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0205.Count; i++)
            {
                registro += getUtil().fill("0205")
                        + getUtil().fill(listaRegistro0205[i].getDescrAntItem())
                        + getUtil().fill(listaRegistro0205[i].getDtIni())
                        + getUtil().fill(listaRegistro0205[i].getDtFin())
                        + getUtil().fill(listaRegistro0205[i].getCodAntItem())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0205((int)(getQuantidadeRegistros0205() + 1));
            }
            return registro;
        }

        public String writeRegistro0400(List<Registro0400> listaRegistro0400)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0400.Count; i++)
            {
                registro += getUtil().fill("0400")
                        + getUtil().fill(listaRegistro0400[i].getCodNat())
                        + getUtil().fill(listaRegistro0400[i].getDescrNat())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0400((int)(getQuantidadeRegistros0400() + 1));
            }
            return registro;
        }

        public String writeRegistro0450(List<Registro0450> listaRegistro0450)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0450.Count; i++)
            {
                registro += getUtil().fill("0450")
                        + getUtil().fill(listaRegistro0450[i].getCodInf())
                        + getUtil().fill(listaRegistro0450[i].getTxt())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0450((int)(getQuantidadeRegistros0450() + 1));
            }
            return registro;
        }

        public String writeRegistro0500(List<Registro0500> listaRegistro0500)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0500.Count; i++)
            {
                registro += getUtil().fill("0500")
                        + getUtil().fill(listaRegistro0500[i].getDtAlt())
                        + getUtil().fill(listaRegistro0500[i].getCodNatCc())
                        + getUtil().fill(listaRegistro0500[i].getIndCta())
                        + getUtil().fill(listaRegistro0500[i].getNivel())
                        + getUtil().fill(listaRegistro0500[i].getCodCta())
                        + getUtil().fill(listaRegistro0500[i].getNomeCta())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0500((int)(getQuantidadeRegistros0500() + 1));
            }
            return registro;
        }

        public String writeRegistro0600(List<Registro0600> listaRegistro0600)
        {
            String registro = "";
            for (int i = 0; i < listaRegistro0600.Count; i++)
            {
                registro += getUtil().fill("0600")
                        + getUtil().fill(listaRegistro0600[i].getDtAlt())
                        + getUtil().fill(listaRegistro0600[i].getCodCcus())
                        + getUtil().fill(listaRegistro0600[i].getCcus())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistro0990().setQtdLin0(getRegistro0990().getQtdLin0() + 1);
                setQuantidadeRegistros0600((int)(getQuantidadeRegistros0600() + 1));
            }
            return registro;
        }

        public String writeRegistro0990()
        {
            return getUtil().fill("0990")
                    + getUtil().fill(getRegistro0990().getQtdLin0())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registro0000
         */
        public Registro0000 getRegistro0000()
        {
            return registro0000;
        }

        /**
         * @param registro0000 the registro0000 to set
         */
        public void setRegistro0000(Registro0000 registro0000)
        {
            this.registro0000 = registro0000;
        }

        /**
         * @return the registro0001
         */
        public Registro0001 getRegistro0001()
        {
            return registro0001;
        }

        /**
         * @param registro0001 the registro0001 to set
         */
        public void setRegistro0001(Registro0001 registro0001)
        {
            this.registro0001 = registro0001;
        }

        /**
         * @return the registro0990
         */
        public Registro0990 getRegistro0990()
        {
            return registro0990;
        }

        /**
         * @param registro0990 the registro0990 to set
         */
        public void setRegistro0990(Registro0990 registro0990)
        {
            this.registro0990 = registro0990;
        }

        /**
         * @return the util
         */
        public SpedUtil getUtil()
        {
            return util;
        }

        /**
         * @param util the util to set
         */
        public void setUtil(SpedUtil util)
        {
            this.util = util;
        }

        /**
         * @return the registro0100
         */
        public Registro0100 getRegistro0100()
        {
            return registro0100;
        }

        /**
         * @return the registro0110
         */
        public Registro0110 getRegistro0110()
        {
            return registro0110;
        }

        /**
         * @return the registro0140
         */
        public Registro0140 getRegistro0140()
        {
            return registro0140;
        }

        /**
         * @return the quantidadeRegistros0150
         */
        public int getQuantidadeRegistros0150()
        {
            return quantidadeRegistros0150;
        }

        /**
         * @param quantidadeRegistros0150 the quantidadeRegistros0150 to set
         */
        public void setQuantidadeRegistros0150(int quantidadeRegistros0150)
        {
            this.quantidadeRegistros0150 = quantidadeRegistros0150;
        }

        /**
         * @return the quantidadeRegistros0190
         */
        public int getQuantidadeRegistros0190()
        {
            return quantidadeRegistros0190;
        }

        /**
         * @param quantidadeRegistros0190 the quantidadeRegistros0190 to set
         */
        public void setQuantidadeRegistros0190(int quantidadeRegistros0190)
        {
            this.quantidadeRegistros0190 = quantidadeRegistros0190;
        }

        /**
         * @return the quantidadeRegistros0200
         */
        public int getQuantidadeRegistros0200()
        {
            return quantidadeRegistros0200;
        }

        /**
         * @param quantidadeRegistros0200 the quantidadeRegistros0200 to set
         */
        public void setQuantidadeRegistros0200(int quantidadeRegistros0200)
        {
            this.quantidadeRegistros0200 = quantidadeRegistros0200;
        }

        /**
         * @return the quantidadeRegistros0205
         */
        public int getQuantidadeRegistros0205()
        {
            return quantidadeRegistros0205;
        }

        /**
         * @param quantidadeRegistros0205 the quantidadeRegistros0205 to set
         */
        public void setQuantidadeRegistros0205(int quantidadeRegistros0205)
        {
            this.quantidadeRegistros0205 = quantidadeRegistros0205;
        }

        /**
         * @return the quantidadeRegistros0400
         */
        public int getQuantidadeRegistros0400()
        {
            return quantidadeRegistros0400;
        }

        /**
         * @param quantidadeRegistros0400 the quantidadeRegistros0400 to set
         */
        public void setQuantidadeRegistros0400(int quantidadeRegistros0400)
        {
            this.quantidadeRegistros0400 = quantidadeRegistros0400;
        }

        /**
         * @return the quantidadeRegistros0450
         */
        public int getQuantidadeRegistros0450()
        {
            return quantidadeRegistros0450;
        }

        /**
         * @param quantidadeRegistros0450 the quantidadeRegistros0450 to set
         */
        public void setQuantidadeRegistros0450(int quantidadeRegistros0450)
        {
            this.quantidadeRegistros0450 = quantidadeRegistros0450;
        }

        /**
         * @return the quantidadeRegistros0500
         */
        public int getQuantidadeRegistros0500()
        {
            return quantidadeRegistros0500;
        }

        /**
         * @param quantidadeRegistros0500 the quantidadeRegistros0500 to set
         */
        public void setQuantidadeRegistros0500(int quantidadeRegistros0500)
        {
            this.quantidadeRegistros0500 = quantidadeRegistros0500;
        }

        /**
         * @return the quantidadeRegistros0600
         */
        public int getQuantidadeRegistros0600()
        {
            return quantidadeRegistros0600;
        }

        /**
         * @param quantidadeRegistros0600 the quantidadeRegistros0600 to set
         */
        public void setQuantidadeRegistros0600(int quantidadeRegistros0600)
        {
            this.quantidadeRegistros0600 = quantidadeRegistros0600;
        }
    }
}