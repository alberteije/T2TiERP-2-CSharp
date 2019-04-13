using System;
using System.Collections.Generic;
using System.IO;

namespace ComponenteSpedContribuicoes
{
	public class SpedContribuicoes {

    private Bloco0 bloco0;
    private BlocoA blocoA;
    private BlocoC blocoC;
    private BlocoD blocoD;
    private BlocoF blocoF;
    private BlocoI blocoI;
    private BlocoM blocoM;
    private Bloco1 bloco1;
    private Bloco9 bloco9;
    private SpedUtil spedUtil;
    private List<String> linhasArquivo;

		public SpedContribuicoes() {
			spedUtil = new SpedUtil();
			bloco0 = new Bloco0(spedUtil);
			blocoA = new BlocoA(spedUtil);
			blocoC = new BlocoC(spedUtil);
			blocoD = new BlocoD(spedUtil);
			blocoF = new BlocoF(spedUtil);
			blocoI = new BlocoI(spedUtil);
			blocoM = new BlocoM(spedUtil);
			bloco1 = new Bloco1(spedUtil);
			bloco9 = new Bloco9(spedUtil);
			linhasArquivo = new List<String>();
		}

    public void limpaRegistros() {
        bloco0.limpaRegistros();
        blocoA.limpaRegistros();
        blocoC.limpaRegistros();
        blocoD.limpaRegistros();
        blocoF.limpaRegistros();
        blocoI.limpaRegistros();
        blocoM.limpaRegistros();
        bloco1.limpaRegistros();
        bloco9.limpaRegistros();
    }

    public void geraArquivoTxt(String arquivo) {
        getBloco9().getListaRegistro9900().Clear();

        //bloco 0
        getLinhasArquivo().Add(getBloco0().writeRegistro0000());
        incluiRegistro9900("0000", 1);
        getLinhasArquivo().Add(getBloco0().writeRegistro0001());
        incluiRegistro9900("0001", 1);
        incluiRegistro9900("0100", 1);
        incluiRegistro9900("0140", 1);
        if (getBloco0().getQuantidadeRegistros0150() > 0)
        {
            incluiRegistro9900("0150", getBloco0().getQuantidadeRegistros0150());
        }
        if (getBloco0().getQuantidadeRegistros0190() > 0) {
            incluiRegistro9900("0190", getBloco0().getQuantidadeRegistros0190());
        }
        if (getBloco0().getQuantidadeRegistros0200() > 0) {
            incluiRegistro9900("0200", getBloco0().getQuantidadeRegistros0200());
            if (getBloco0().getQuantidadeRegistros0205() > 0) {
                incluiRegistro9900("0205", getBloco0().getQuantidadeRegistros0205());
            }
        }
        if (getBloco0().getQuantidadeRegistros0400() > 0) {
            incluiRegistro9900("0400", getBloco0().getQuantidadeRegistros0400());
        }
        if (getBloco0().getQuantidadeRegistros0450() > 0) {
            incluiRegistro9900("0450", getBloco0().getQuantidadeRegistros0450());
        }
        if (getBloco0().getQuantidadeRegistros0500() > 0) {
            incluiRegistro9900("0500", getBloco0().getQuantidadeRegistros0500());
        }
        if (getBloco0().getQuantidadeRegistros0600() > 0) {
            incluiRegistro9900("0600", getBloco0().getQuantidadeRegistros0600());
        }
        getLinhasArquivo().Add(getBloco0().writeRegistro0990());
        incluiRegistro9900("0990", 1);

        //bloco A
        getLinhasArquivo().Add(getBlocoA().writeRegistroA001());
        incluiRegistro9900("A001", 1);

        //bloco C
        getLinhasArquivo().Add(getBlocoC().writeRegistroC001());
        incluiRegistro9900("C001", 1);
        if (getBlocoC().getQuantidadeRegistrosC100() > 0) {
            incluiRegistro9900("C100", getBlocoC().getQuantidadeRegistrosC100());
            if (getBlocoC().getQuantidadeRegistrosC110() > 0) {
                incluiRegistro9900("C110", getBlocoC().getQuantidadeRegistrosC110());
            }
        }
        if (getBlocoC().getQuantidadeRegistrosC380() > 0) {
            incluiRegistro9900("C380", getBlocoC().getQuantidadeRegistrosC380());
            /*
             * Exercício: Implementar
             * 
            if (getBlocoC().getQuantidadeRegistrosC381() > 0) {
                incluiRegistro9900("C381", getBlocoC().getQuantidadeRegistrosC381());
            }
            if (getBlocoC().getQuantidadeRegistrosC385() > 0) {
                incluiRegistro9900("C385", getBlocoC().getQuantidadeRegistrosC385());
            }
             */ 
        }
        if (getBlocoC().getQuantidadeRegistrosC400() > 0) {
            incluiRegistro9900("C400", getBlocoC().getQuantidadeRegistrosC400());
            if (getBlocoC().getQuantidadeRegistrosC405() > 0) {
                incluiRegistro9900("C405", getBlocoC().getQuantidadeRegistrosC405());
                if (getBlocoC().getQuantidadeRegistrosC481() > 0) {
                    incluiRegistro9900("C481", getBlocoC().getQuantidadeRegistrosC481());
                }
                if (getBlocoC().getQuantidadeRegistrosC485() > 0)
                {
                    incluiRegistro9900("C485", getBlocoC().getQuantidadeRegistrosC485());
                }
            }
        }
        getLinhasArquivo().Add(getBlocoC().writeRegistroC990());
        incluiRegistro9900("C990", 1);

        //bloco D
        getLinhasArquivo().Add(getBlocoD().writeRegistroD001());
        incluiRegistro9900("D001", 1);

        //bloco F
        getLinhasArquivo().Add(getBlocoF().writeRegistroF001());
        incluiRegistro9900("F001", 1);

        //bloco I
        getLinhasArquivo().Add(getBlocoI().writeRegistroI001());
        incluiRegistro9900("I001", 1);

        //bloco M
        getLinhasArquivo().Add(getBlocoM().writeRegistroM001());
        incluiRegistro9900("M001", 1);

        //bloco 1
        getLinhasArquivo().Add(getBloco1().writeRegistro1001());
        incluiRegistro9900("1001", 1);
        
        //bloco 9
        getLinhasArquivo().Add(getBloco9().writeRegistro9001());
        incluiRegistro9900("9001", 1);

        incluiRegistro9900("9900", getBloco9().getListaRegistro9900().Count + 2);
        incluiRegistro9900("9990", 1);
        incluiRegistro9900("9999", 1);
        getLinhasArquivo().Add(getBloco9().writeRegistro9900());
        getLinhasArquivo().Add(getBloco9().writeRegistro9990());

        getBloco9().getRegistro9999().setQtdLin(
                getBloco0().getRegistro0990().getQtdLin0()
                + getBlocoA().getRegistroA990().getQtdLinA()
                + getBlocoC().getRegistroC990().getQtdLinC()
                + getBlocoD().getRegistroD990().getQtdLinD()
                + getBlocoF().getRegistroF990().getQtdLinF()
                + getBlocoI().getRegistroI990().getQtdLinI()
                + getBlocoM().getRegistroM990().getQtdLinM()
                + getBloco1().getRegistro1990().getQtdLin1()
                + getBloco9().getRegistro9990().getQtdLin9());
        getLinhasArquivo().Add(getBloco9().writeRegistro9999());

        DirectoryInfo di = new DirectoryInfo(@"c:\\T2Ti\\Arquivos\\");

        SpedUtil.WriteLines(di, arquivo, getLinhasArquivo());
    }

    private void incluiRegistro9900(String registro, int quantidade) {
        Registro9900 registro9900 = new Registro9900();
        registro9900.setRegBlc(registro);
        registro9900.setQtdRegBlc(quantidade);

        getBloco9().getListaRegistro9900().Add(registro9900);
    }

    public String getDelimitador() {
        return getSpedUtil().getDelimitador();
    }

    public void setDelimitador(String delimitador) {
        getSpedUtil().setDelimitador(delimitador);
    }

    /**
     * @return the bloco9
     */
    public Bloco9 getBloco9() {
        return bloco9;
    }

    /**
     * @param bloco9 the bloco9 to set
     */
    public void setBloco9(Bloco9 bloco9)
    {
        this.bloco9 = bloco9;
    }

    /**
        * @return the bloco0
        */
    public Bloco0 getBloco0() {
        return bloco0;
    }

    /**
        * @param bloco0 the bloco0 to set
        */
    public void setBloco0(Bloco0 bloco0) {
        this.bloco0 = bloco0;
    }

    /**
        * @return the bloco1
        */
    public Bloco1 getBloco1()
    {
        return bloco1;
    }

    /**
        * @param bloco1 the bloco1 to set
        */
    public void setBloco1(Bloco1 bloco1)
    {
        this.bloco1 = bloco1;
    }

    /**
     * @return the blocoA
     */
    public BlocoA getBlocoA()
    {
        return blocoA;
    }

    /**
     * @param blocoA the blocoA to set
     */
    public void setBlocoA(BlocoA blocoA)
    {
        this.blocoA = blocoA;
    }

    /**
     * @return the blocoC
     */
    public BlocoC getBlocoC() {
        return blocoC;
    }

    /**
     * @param blocoC the blocoC to set
     */
    public void setBlocoC(BlocoC blocoC) {
        this.blocoC = blocoC;
    }

    /**
     * @return the blocoD
     */
    public BlocoD getBlocoD()
    {
        return blocoD;
    }

    /**
     * @param blocoD the blocoD to set
     */
    public void setBlocoD(BlocoD blocoD)
    {
        this.blocoD = blocoD;
    }

    /**
     * @return the blocoF
     */
    public BlocoF getBlocoF()
    {
        return blocoF;
    }

    /**
     * @param blocoF the blocoF to set
     */
    public void setBlocoF(BlocoF blocoF)
    {
        this.blocoF = blocoF;
    }

    /**
     * @return the blocoI
     */
    public BlocoI getBlocoI()
    {
        return blocoI;
    }

    /**
     * @param blocoI the blocoI to set
     */
    public void setBlocoI(BlocoI blocoI)
    {
        this.blocoI = blocoI;
    }

    /**
     * @return the blocoM
     */
    public BlocoM getBlocoM()
    {
        return blocoM;
    }

    /**
     * @param blocoM the blocoM to set
     */
    public void setBlocoM(BlocoM blocoM)
    {
        this.blocoM = blocoM;
    }

    /**
     * @return the spedUtil
     */
    public SpedUtil getSpedUtil() {
        return spedUtil;
    }

    /**
     * @param spedUtil the spedUtil to set
     */
    public void setSpedUtil(SpedUtil spedUtil) {
        this.spedUtil = spedUtil;
    }

    /**
     * @return the linhasArquivo
     */
    public List<String> getLinhasArquivo() {
        return linhasArquivo;
    }

    /**
     * @param linhasArquivo the linhasArquivo to set
     */
    public void setLinhasArquivo(List<String> linhasArquivo) {
        this.linhasArquivo = linhasArquivo;
    }

}
}