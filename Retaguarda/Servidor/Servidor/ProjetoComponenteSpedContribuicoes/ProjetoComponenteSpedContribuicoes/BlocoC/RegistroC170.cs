/*
* The MIT License
* 
* Copyright: Copyright (C) 2014 T2Ti.COM
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
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
* 
* The author may be contacted at: t2ti.com@gmail.com
*
* @author Albert Eije (T2Ti.com)
* @version 2.0
*/
using System;
using System.Collections.Generic;

namespace ComponenteSpedContribuicoes
{

    public class RegistroC170
    {

        private String numItem; // Número seqüencial do item no documento fiscal
        private String codItem; // Código do item (campo 02 do Registro 0200)
        private String descrCompl; // Descrição complementar do item como adotado no documento fiscal
        private Decimal qtd; // Quantidade do item
        private String unid; // Unidade do item(Campo 02 do registro 0190)
        private Decimal vlItem; // Valor total do item
        private Decimal vlDesc; // Valor do desconto comercial
        private int indMov; // Movimentação física do ITEM/PRODUTO: 0 - SIM; 1- NÃO
        private String cstIcms; // Código da Situação Tributária referente ao ICMS, conforme a Tabela indicada no item 4.3.1
        private String cfop; // Código Fiscal de Operação e Prestação
        private String codNat; // Código da natureza da operação (campo 02 do Registro 0400)
        private Decimal vlBcIcms; // Valor da base de cálculo do ICMS
        private Decimal aliqIcms; // Alíquota do ICMS
        private Decimal vlIcms; // Valor do ICMS creditado/debitado
        private Decimal vlBcIcmsSt; // Valor da base de cálculo referente à substituição tributária
        private Decimal aliqSt; // Alíquota do ICMS da substituição tributária na unidade da federação de destino
        private Decimal vlIcmsSt; // Valor do ICMS referente à substituição tributária
        private int indApur; // Indicador de período de apuração do IPI: 0 - Mensal; 1 - Decendial
        private String cstIpi; // Código da Situação Tributária referente ao IPI, conforme a Tabela indicada no item 4.3.2.
        private String codEnq; // Código de enquadramento legal do IPI, conforme tabela indicada no item 4.5.3.
        private Decimal vlBcIpi; // Valor da base de cálculo do IPI
        private Decimal aliqIpi; // Alíquota do IPI
        private Decimal vlIpi; // Valor do IPI creditado/debitado
        private String cstPis; // Código da Situação Tributária referente ao PIS.
        private Decimal vlBcPis; // Valor da base de cálculo do PIS
        private Decimal aliqPisPerc; // Alíquota do PIS (em percentual)
        private Decimal quantBcPis; // Quantidade - Base de cálculo PIS
        private Decimal aliqPisR; // Alíquota do PIS (em reais)
        private Decimal vlPis; // Valor do PIS
        private String cstCofins; // Código da Situação Tributária referente ao COFINS.
        private Decimal vlBcCofins; // Valor da base de cálculo da COFINS
        private Decimal aliqCofinsPerc; // Alíquota do COFINS (em percentual)
        private Decimal quantBcCofins; // Quantidade - Base de cálculo COFINS
        private Decimal aliqCofinsR; // Alíquota da COFINS (em reais)
        private Decimal vlCofins; // Valor da COFINS
        private String codCta; // Código da conta analítica contábil debitada/creditada

        public String getNumItem()
        {
            return numItem;
        }

        public void setNumItem(String numItem)
        {
            this.numItem = numItem;
        }

        public String getCodItem()
        {
            return codItem;
        }

        public void setCodItem(String codItem)
        {
            this.codItem = codItem;
        }

        public String getDescrCompl()
        {
            return descrCompl;
        }

        public void setDescrCompl(String descrCompl)
        {
            this.descrCompl = descrCompl;
        }

        public Decimal getQtd()
        {
            return qtd;
        }

        public void setQtd(Decimal qtd)
        {
            this.qtd = qtd;
        }

        public String getUnid()
        {
            return unid;
        }

        public void setUnid(String unid)
        {
            this.unid = unid;
        }

        public Decimal getVlItem()
        {
            return vlItem;
        }

        public void setVlItem(Decimal vlItem)
        {
            this.vlItem = vlItem;
        }

        public Decimal getVlDesc()
        {
            return vlDesc;
        }

        public void setVlDesc(Decimal vlDesc)
        {
            this.vlDesc = vlDesc;
        }

        public int getIndMov()
        {
            return indMov;
        }

        public void setIndMov(int indMov)
        {
            this.indMov = indMov;
        }

        public String getCstIcms()
        {
            return cstIcms;
        }

        public void setCstIcms(String cstIcms)
        {
            this.cstIcms = cstIcms;
        }

        public String getCfop()
        {
            return cfop;
        }

        public void setCfop(String cfop)
        {
            this.cfop = cfop;
        }

        public String getCodNat()
        {
            return codNat;
        }

        public void setCodNat(String codNat)
        {
            this.codNat = codNat;
        }

        public Decimal getVlBcIcms()
        {
            return vlBcIcms;
        }

        public void setVlBcIcms(Decimal vlBcIcms)
        {
            this.vlBcIcms = vlBcIcms;
        }

        public Decimal getAliqIcms()
        {
            return aliqIcms;
        }

        public void setAliqIcms(Decimal aliqIcms)
        {
            this.aliqIcms = aliqIcms;
        }

        public Decimal getVlIcms()
        {
            return vlIcms;
        }

        public void setVlIcms(Decimal vlIcms)
        {
            this.vlIcms = vlIcms;
        }

        public Decimal getVlBcIcmsSt()
        {
            return vlBcIcmsSt;
        }

        public void setVlBcIcmsSt(Decimal vlBcIcmsSt)
        {
            this.vlBcIcmsSt = vlBcIcmsSt;
        }

        public Decimal getAliqSt()
        {
            return aliqSt;
        }

        public void setAliqSt(Decimal aliqSt)
        {
            this.aliqSt = aliqSt;
        }

        public Decimal getVlIcmsSt()
        {
            return vlIcmsSt;
        }

        public void setVlIcmsSt(Decimal vlIcmsSt)
        {
            this.vlIcmsSt = vlIcmsSt;
        }

        public int getIndApur()
        {
            return indApur;
        }

        public void setIndApur(int indApur)
        {
            this.indApur = indApur;
        }

        public String getCstIpi()
        {
            return cstIpi;
        }

        public void setCstIpi(String cstIpi)
        {
            this.cstIpi = cstIpi;
        }

        public String getCodEnq()
        {
            return codEnq;
        }

        public void setCodEnq(String codEnq)
        {
            this.codEnq = codEnq;
        }

        public Decimal getVlBcIpi()
        {
            return vlBcIpi;
        }

        public void setVlBcIpi(Decimal vlBcIpi)
        {
            this.vlBcIpi = vlBcIpi;
        }

        public Decimal getAliqIpi()
        {
            return aliqIpi;
        }

        public void setAliqIpi(Decimal aliqIpi)
        {
            this.aliqIpi = aliqIpi;
        }

        public Decimal getVlIpi()
        {
            return vlIpi;
        }

        public void setVlIpi(Decimal vlIpi)
        {
            this.vlIpi = vlIpi;
        }

        public String getCstPis()
        {
            return cstPis;
        }

        public void setCstPis(String cstPis)
        {
            this.cstPis = cstPis;
        }

        public Decimal getVlBcPis()
        {
            return vlBcPis;
        }

        public void setVlBcPis(Decimal vlBcPis)
        {
            this.vlBcPis = vlBcPis;
        }

        public Decimal getAliqPisPerc()
        {
            return aliqPisPerc;
        }

        public void setAliqPisPerc(Decimal aliqPisPerc)
        {
            this.aliqPisPerc = aliqPisPerc;
        }

        public Decimal getQuantBcPis()
        {
            return quantBcPis;
        }

        public void setQuantBcPis(Decimal quantBcPis)
        {
            this.quantBcPis = quantBcPis;
        }

        public Decimal getAliqPisR()
        {
            return aliqPisR;
        }

        public void setAliqPisR(Decimal aliqPisR)
        {
            this.aliqPisR = aliqPisR;
        }

        public Decimal getVlPis()
        {
            return vlPis;
        }

        public void setVlPis(Decimal vlPis)
        {
            this.vlPis = vlPis;
        }

        public String getCstCofins()
        {
            return cstCofins;
        }

        public void setCstCofins(String cstCofins)
        {
            this.cstCofins = cstCofins;
        }

        public Decimal getVlBcCofins()
        {
            return vlBcCofins;
        }

        public void setVlBcCofins(Decimal vlBcCofins)
        {
            this.vlBcCofins = vlBcCofins;
        }

        public Decimal getAliqCofinsPerc()
        {
            return aliqCofinsPerc;
        }

        public void setAliqCofinsPerc(Decimal aliqCofinsPerc)
        {
            this.aliqCofinsPerc = aliqCofinsPerc;
        }

        public Decimal getQuantBcCofins()
        {
            return quantBcCofins;
        }

        public void setQuantBcCofins(Decimal quantBcCofins)
        {
            this.quantBcCofins = quantBcCofins;
        }

        public Decimal getAliqCofinsR()
        {
            return aliqCofinsR;
        }

        public void setAliqCofinsR(Decimal aliqCofinsR)
        {
            this.aliqCofinsR = aliqCofinsR;
        }

        public Decimal getVlCofins()
        {
            return vlCofins;
        }

        public void setVlCofins(Decimal vlCofins)
        {
            this.vlCofins = vlCofins;
        }

        public String getCodCta()
        {
            return codCta;
        }

        public void setCodCta(String codCta)
        {
            this.codCta = codCta;
        }
    }
}