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

    public class BlocoC
    {

        private RegistroC001 registroC001;
        private RegistroC010 registroC010;
        private int quantidadeRegistrosC100;
        private int quantidadeRegistrosC110;
        private int quantidadeRegistrosC170;
        private int quantidadeRegistrosC380;
        private int quantidadeRegistrosC400;
        private int quantidadeRegistrosC405;
        private int quantidadeRegistrosC481;
        private int quantidadeRegistrosC485;
        private RegistroC990 registroC990;
        private SpedUtil util;

        public BlocoC(SpedUtil spedUtil)
        {
            registroC001 = new RegistroC001();
            registroC010 = new RegistroC010();
            registroC001.setIndMov(1);

            registroC990 = new RegistroC990();

            registroC990.setQtdLinC(0);

            quantidadeRegistrosC100 = 0;
            quantidadeRegistrosC110 = 0;
            quantidadeRegistrosC170 = 0;
            quantidadeRegistrosC380 = 0;
            quantidadeRegistrosC400 = 0;
            quantidadeRegistrosC405 = 0;
            quantidadeRegistrosC481 = 0;
            quantidadeRegistrosC485 = 0;

            this.util = spedUtil;
        }

        public void limpaRegistros()
        {
            getRegistroC990().setQtdLinC(0);
        }

        public String writeRegistroC001()
        {
            getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);

            String registro = "";
            registro += getUtil().fill("C001")
                    + getUtil().fill(getRegistroC001().getIndMov())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();

            registro += writeRegistroC100(getRegistroC001().getRegistroC100List());
            registro += writeRegistroC380(getRegistroC001().getRegistroC380List());
            registro += writeRegistroC400(getRegistroC001().getRegistroC400List());

            return registro;
        }

        public String writeRegistroC100(List<RegistroC100> listaRegistroC100)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC100.Count; i++)
            {
                registro += getUtil().fill("C100")
                        + getUtil().fill(listaRegistroC100[i].getIndOper())
                        + getUtil().fill(listaRegistroC100[i].getIndEmit())
                        + getUtil().fill(listaRegistroC100[i].getCodPart())
                        + getUtil().fill(listaRegistroC100[i].getCodMod())
                        + getUtil().fill(listaRegistroC100[i].getCodSit())
                        + getUtil().fill(listaRegistroC100[i].getSer())
                        + getUtil().fill(listaRegistroC100[i].getNumDoc())
                        + getUtil().fill(listaRegistroC100[i].getChvNfe())
                        + getUtil().fill(listaRegistroC100[i].getDtDoc())
                        + getUtil().fill(listaRegistroC100[i].getDtES())
                        + getUtil().fill(listaRegistroC100[i].getVlDoc())
                        + getUtil().fill(listaRegistroC100[i].getIndPgto())
                        + getUtil().fill(listaRegistroC100[i].getVlDesc())
                        + getUtil().fill(listaRegistroC100[i].getVlAbatNt())
                        + getUtil().fill(listaRegistroC100[i].getVlMerc())
                        + getUtil().fill(listaRegistroC100[i].getIndFrt())
                        + getUtil().fill(listaRegistroC100[i].getVlFrt())
                        + getUtil().fill(listaRegistroC100[i].getVlSeg())
                        + getUtil().fill(listaRegistroC100[i].getVlOutDa())
                        + getUtil().fill(listaRegistroC100[i].getVlBcIcms())
                        + getUtil().fill(listaRegistroC100[i].getVlIcms())
                        + getUtil().fill(listaRegistroC100[i].getVlBcIcmsSt())
                        + getUtil().fill(listaRegistroC100[i].getVlIcmsSt())
                        + getUtil().fill(listaRegistroC100[i].getVlIpi())
                        + getUtil().fill(listaRegistroC100[i].getVlPis())
                        + getUtil().fill(listaRegistroC100[i].getVlCofins())
                        + getUtil().fill(listaRegistroC100[i].getVlPisSt())
                        + getUtil().fill(listaRegistroC100[i].getVlCofinsSt())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                registro += writeRegistroC110(listaRegistroC100[i].getRegistroC110List());
                registro += writeRegistroC170(listaRegistroC100[i].getRegistroC170List());

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC100((int)(getQuantidadeRegistrosC100() + 1));
            }
            return registro;
        }

        public String writeRegistroC110(List<RegistroC110> listaRegistroC110)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC110.Count; i++)
            {
                registro += getUtil().fill("C110")
                        + getUtil().fill(listaRegistroC110[i].getCodInf())
                        + getUtil().fill(listaRegistroC110[i].getTxtCompl())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC110((int)(getQuantidadeRegistrosC110() + 1));
            }
            return registro;
        }

        private String writeRegistroC170(List<RegistroC170> listaRegistroC170)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC170.Count; i++)
            {
                registro += getUtil().fill("C170")
                        + getUtil().fill(listaRegistroC170[i].getNumItem())
                        + getUtil().fill(listaRegistroC170[i].getCodItem())
                        + getUtil().fill(listaRegistroC170[i].getDescrCompl())
                        + getUtil().fill(listaRegistroC170[i].getQtd())
                        + getUtil().fill(listaRegistroC170[i].getUnid())
                        + getUtil().fill(listaRegistroC170[i].getVlItem())
                        + getUtil().fill(listaRegistroC170[i].getVlDesc())
                        + getUtil().fill(listaRegistroC170[i].getIndMov())
                        + getUtil().fill(listaRegistroC170[i].getCstIcms())
                        + getUtil().fill(listaRegistroC170[i].getCfop())
                        + getUtil().fill(listaRegistroC170[i].getCodNat())
                        + getUtil().fill(listaRegistroC170[i].getVlBcIcms())
                        + getUtil().fill(listaRegistroC170[i].getAliqIcms())
                        + getUtil().fill(listaRegistroC170[i].getVlIcms())
                        + getUtil().fill(listaRegistroC170[i].getVlBcIcmsSt())
                        + getUtil().fill(listaRegistroC170[i].getAliqSt())
                        + getUtil().fill(listaRegistroC170[i].getVlIcmsSt())
                        + getUtil().fill(listaRegistroC170[i].getIndApur())
                        + getUtil().fill(listaRegistroC170[i].getCstIpi())
                        + getUtil().fill(listaRegistroC170[i].getCodEnq())
                        + getUtil().fill(listaRegistroC170[i].getVlBcIpi())
                        + getUtil().fill(listaRegistroC170[i].getAliqIpi())
                        + getUtil().fill(listaRegistroC170[i].getVlIpi())
                        + getUtil().fill(listaRegistroC170[i].getCstPis())
                        + getUtil().fill(listaRegistroC170[i].getVlBcPis())
                        + getUtil().fill(listaRegistroC170[i].getAliqPisPerc())
                        + getUtil().fill(listaRegistroC170[i].getQuantBcPis())
                        + getUtil().fill(listaRegistroC170[i].getAliqPisR())
                        + getUtil().fill(listaRegistroC170[i].getVlPis())
                        + getUtil().fill(listaRegistroC170[i].getCstCofins())
                        + getUtil().fill(listaRegistroC170[i].getVlBcCofins())
                        + getUtil().fill(listaRegistroC170[i].getAliqCofinsPerc())
                        + getUtil().fill(listaRegistroC170[i].getQuantBcCofins())
                        + getUtil().fill(listaRegistroC170[i].getAliqCofinsR())
                        + getUtil().fill(listaRegistroC170[i].getVlCofins())
                        + getUtil().fill(listaRegistroC170[i].getCodCta())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                registroC990.setQtdLinC(registroC990.getQtdLinC() + 1);
                setQuantidadeRegistrosC170((int)(getQuantidadeRegistrosC170() + 1));
            }
            return registro;
        }
        public String writeRegistroC380(List<RegistroC380> listaRegistroC380)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC380.Count; i++)
            {
                registro += getUtil().fill("C380")
                        + getUtil().fill(listaRegistroC380[i].getCodMod())
                        + getUtil().fill(listaRegistroC380[i].getDtDocIni())
                        + getUtil().fill(listaRegistroC380[i].getDtDocFin())
                        + getUtil().fill(listaRegistroC380[i].getNumDocIni())
                        + getUtil().fill(listaRegistroC380[i].getNumDocFin())
                        + getUtil().fill(listaRegistroC380[i].getVlDoc())
                        + getUtil().fill(listaRegistroC380[i].getvlDocCanc())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                //registro += writeRegistroC381(listaRegistroC380[i].getRegistroC381List());
                //registro += writeRegistroC385(listaRegistroC380[i].getRegistroC385List());

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC380((int)(getQuantidadeRegistrosC380() + 1));
            }
            return registro;
        }

        public String writeRegistroC400(List<RegistroC400> listaRegistroC400)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC400.Count; i++)
            {
                registro += getUtil().fill("C400")
                        + getUtil().fill(listaRegistroC400[i].getCodMod())
                        + getUtil().fill(listaRegistroC400[i].getEcfMod())
                        + getUtil().fill(listaRegistroC400[i].getEcfFab())
                        + getUtil().fill(listaRegistroC400[i].getEcfCx())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                registro += writeRegistroC405(listaRegistroC400[i].getRegistroC405List());

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC400((int)(getQuantidadeRegistrosC400() + 1));
            }
            return registro;
        }

        public String writeRegistroC405(List<RegistroC405> listaRegistroC405)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC405.Count; i++)
            {
                registro += getUtil().fill("C405")
                        + getUtil().fill(listaRegistroC405[i].getDtDoc())
                        + getUtil().fill(listaRegistroC405[i].getCro())
                        + getUtil().fill(listaRegistroC405[i].getCrz())
                        + getUtil().fill(listaRegistroC405[i].getNumCooFin())
                        + getUtil().fill(listaRegistroC405[i].getGtFin())
                        + getUtil().fill(listaRegistroC405[i].getVlBrt())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                registro += writeRegistroC481(listaRegistroC405[i].getRegistroC481List());
                registro += writeRegistroC485(listaRegistroC405[i].getRegistroC485List());

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC405((int)(getQuantidadeRegistrosC405() + 1));
            }
            return registro;
        }

        public String writeRegistroC481(List<RegistroC481> listaRegistroC481)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC481.Count; i++)
            {
                registro += getUtil().fill("C481")
                        + getUtil().fill(listaRegistroC481[i].getCodItem())
                        + getUtil().fill(listaRegistroC481[i].getQtd())
                        + getUtil().fill(listaRegistroC481[i].getUnid())
                        + getUtil().fill(listaRegistroC481[i].getVlItem())
                        + getUtil().fill(listaRegistroC481[i].getVlPis())
                        + getUtil().fill(listaRegistroC481[i].getVlCofins())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC481((int)(getQuantidadeRegistrosC481() + 1));
            }
            return registro;
        }

        public String writeRegistroC485(List<RegistroC485> listaRegistroC485)
        {
            String registro = "";
            for (int i = 0; i < listaRegistroC485.Count; i++)
            {
                registro += getUtil().fill("C485")
                        + getUtil().fill(listaRegistroC485[i].getCodItem())
                        + getUtil().fill(listaRegistroC485[i].getQtd())
                        + getUtil().fill(listaRegistroC485[i].getUnid())
                        + getUtil().fill(listaRegistroC485[i].getVlItem())
                        + getUtil().fill(listaRegistroC485[i].getVlPis())
                        + getUtil().fill(listaRegistroC485[i].getVlCofins())
                        + getUtil().getDelimitador()
                        + getUtil().getCrlf();

                getRegistroC990().setQtdLinC(getRegistroC990().getQtdLinC() + 1);
                setQuantidadeRegistrosC485((int)(getQuantidadeRegistrosC485() + 1));
            }
            return registro;
        }

        
        public String writeRegistroC990()
        {
            return getUtil().fill("C990")
                    + getUtil().fill(getRegistroC990().getQtdLinC())
                    + getUtil().getDelimitador()
                    + getUtil().getCrlf();
        }

        /**
         * @return the registroC001
         */
        public RegistroC001 getRegistroC001()
        {
            return registroC001;
        }

        /**
         * @return the registroC010
         */
        public RegistroC010 getRegistroC010()
        {
            return registroC010;
        }

        /**
         * @param registroC001 the registroC001 to set
         */
        public void setRegistroC001(RegistroC001 registroC001)
        {
            this.registroC001 = registroC001;
        }

        /**
         * @return the quantidadeRegistrosC100
         */
        public int getQuantidadeRegistrosC100()
        {
            return quantidadeRegistrosC100;
        }

        /**
         * @param quantidadeRegistrosC100 the quantidadeRegistrosC100 to set
         */
        public void setQuantidadeRegistrosC100(int quantidadeRegistrosC100)
        {
            this.quantidadeRegistrosC100 = quantidadeRegistrosC100;
        }

        /**
         * @return the quantidadeRegistrosC380
         */
        public int getQuantidadeRegistrosC380()
        {
            return quantidadeRegistrosC380;
        }

        /**
         * @param quantidadeRegistrosC380 the quantidadeRegistrosC380 to set
         */
        public void setQuantidadeRegistrosC380(int quantidadeRegistrosC380)
        {
            this.quantidadeRegistrosC380 = quantidadeRegistrosC380;
        }

        /**
         * @return the quantidadeRegistrosC400
         */
        public int getQuantidadeRegistrosC400()
        {
            return quantidadeRegistrosC400;
        }

        /**
         * @param quantidadeRegistrosC400 the quantidadeRegistrosC400 to set
         */
        public void setQuantidadeRegistrosC400(int quantidadeRegistrosC400)
        {
            this.quantidadeRegistrosC400 = quantidadeRegistrosC400;
        }

        /**
         * @return the quantidadeRegistrosC405
         */
        public int getQuantidadeRegistrosC405()
        {
            return quantidadeRegistrosC405;
        }

        /**
         * @param quantidadeRegistrosC405 the quantidadeRegistrosC405 to set
         */
        public void setQuantidadeRegistrosC405(int quantidadeRegistrosC405)
        {
            this.quantidadeRegistrosC405 = quantidadeRegistrosC405;
        }

        /**
         * @return the quantidadeRegistrosC481
         */
        public int getQuantidadeRegistrosC481()
        {
            return quantidadeRegistrosC481;
        }

        /**
         * @param quantidadeRegistrosC481 the quantidadeRegistrosC481 to set
         */
        public void setQuantidadeRegistrosC481(int quantidadeRegistrosC481)
        {
            this.quantidadeRegistrosC481 = quantidadeRegistrosC481;
        }

        /**
         * @return the quantidadeRegistrosC485
         */
        public int getQuantidadeRegistrosC485()
        {
            return quantidadeRegistrosC485;
        }

        /**
         * @param quantidadeRegistrosC485 the quantidadeRegistrosC485 to set
         */
        public void setQuantidadeRegistrosC485(int quantidadeRegistrosC485)
        {
            this.quantidadeRegistrosC485 = quantidadeRegistrosC485;
        }

        /**
         * @return the registroC990
         */
        public RegistroC990 getRegistroC990()
        {
            return registroC990;
        }

        /**
         * @param registroC990 the registroC990 to set
         */
        public void setRegistroC990(RegistroC990 registroC990)
        {
            this.registroC990 = registroC990;
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
         * @return the quantidadeRegistrosC110
         */
        public int getQuantidadeRegistrosC110()
        {
            return quantidadeRegistrosC110;
        }

        /**
         * @param quantidadeRegistrosC110 the quantidadeRegistrosC110 to set
         */
        public void setQuantidadeRegistrosC110(int quantidadeRegistrosC110)
        {
            this.quantidadeRegistrosC110 = quantidadeRegistrosC110;
        }

        /**
         * @return the quantidadeRegistrosC170
         */
        public int getQuantidadeRegistrosC170()
        {
            return quantidadeRegistrosC170;
        }

        /**
         * @param quantidadeRegistrosC170 the quantidadeRegistrosC170 to set
         */
        public void setQuantidadeRegistrosC170(int quantidadeRegistrosC170)
        {
            this.quantidadeRegistrosC170 = quantidadeRegistrosC170;
        }

    }
}