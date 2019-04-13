using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;

namespace ComponentePonto
{
    public class ComponentePonto
    {

        public static int NSR;

        public AFDT_Cabecalho AFDTCabecalho { get; set; }
        public List<AFDT_Registro2> ListaAFDTRegistro2 = new List<AFDT_Registro2>();
        public AFDT_Trailer AFDTTrailer { get; set; }

        public ACJEF_Cabecalho ACJEFCabecalho { get; set; }
        public List<ACJEF_Registro2> ListaACJEFRegistro2 = new List<ACJEF_Registro2>();
        public List<ACJEF_Registro3> ListaACJEFRegistro3 = new List<ACJEF_Registro3>();
        public ACJEF_Trailer ACJEFTrailer { get; set; }

        public Ponto_AFD pontoAFD { get; set; }

        public ComponentePonto()
        {
            NSR = 0;  
        }

        public void gerarArquivoAFDT(string salvarEm)
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine(AFDTCabecalho.gerarLinhaTexto());

            foreach (AFDT_Registro2 AFDTRegistro2 in ListaAFDTRegistro2)
            {
                sb.AppendLine(AFDTRegistro2.gerarLinhaTexto());
            }

            sb.AppendLine(AFDTTrailer.gerarLinhaTexto());
            
            TextWriter tw = new StreamWriter(salvarEm);
            tw.Write(sb.ToString());
            tw.Close();

            if (File.Exists(salvarEm))
                Process.Start(salvarEm);
        }

        public void gerarArquivoACJEF(string salvarEm)
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine(ACJEFCabecalho.gerarLinhaTexto());

            foreach (ACJEF_Registro2 ACJEFRegistro2 in ListaACJEFRegistro2)
            {
                sb.AppendLine(ACJEFRegistro2.gerarLinhaTexto());
            }

            foreach (ACJEF_Registro3 ACJEFRegistro3 in ListaACJEFRegistro3)
            {
                sb.AppendLine(ACJEFRegistro3.gerarLinhaTexto());
            }

            sb.AppendLine(ACJEFTrailer.gerarLinhaTexto());

            TextWriter tw = new StreamWriter(salvarEm);
            tw.Write(sb.ToString());
            tw.Close();

            if (File.Exists(salvarEm))
                Process.Start(salvarEm);
        }

        public void processarArquivoAFD(string caminho)
        {
            pontoAFD = new Ponto_AFD();
            string Linha = "";

            try
            {
                // carrega o arquivo
                StreamReader objReader = new StreamReader(caminho);

                // carrega os dados do arquivo nos objetos
                while ((Linha = objReader.ReadLine()) != null)
                {
                    // Registro 1 - Cabeçalho
                    if (Linha.Substring(9, 1) == "1")
                    {
                        pontoAFD.AFDCabecalho.Campo01 = Linha.Substring(0, 9);
                        pontoAFD.AFDCabecalho.Campo02 = Linha.Substring(9, 1);
                        pontoAFD.AFDCabecalho.Campo03 = Linha.Substring(10, 1);
                        pontoAFD.AFDCabecalho.Campo04 = Linha.Substring(11, 14);
                        pontoAFD.AFDCabecalho.Campo05 = Linha.Substring(25, 12);
                        pontoAFD.AFDCabecalho.Campo06 = Linha.Substring(37, 150);
                        pontoAFD.AFDCabecalho.Campo07 = Linha.Substring(187, 17);
                        pontoAFD.AFDCabecalho.Campo08 = Linha.Substring(204, 8);
                        pontoAFD.AFDCabecalho.Campo09 = Linha.Substring(212, 8);
                        pontoAFD.AFDCabecalho.Campo10 = Linha.Substring(220, 8);
                        pontoAFD.AFDCabecalho.Campo11 = Linha.Substring(228, Linha.Length - 228);
                    }

                    // Registro 2
                    if (Linha.Substring(9, 1) == "2")
                    {
                        pontoAFD.AFDRegistro2.Campo01 = Linha.Substring(0, 9);
                        pontoAFD.AFDRegistro2.Campo02 = Linha.Substring(9, 1);
                        pontoAFD.AFDRegistro2.Campo03 = Linha.Substring(10, 8);
                        pontoAFD.AFDRegistro2.Campo04 = Linha.Substring(18, 4);
                        pontoAFD.AFDRegistro2.Campo05 = Linha.Substring(22, 1);
                        pontoAFD.AFDRegistro2.Campo06 = Linha.Substring(23, 14);
                        pontoAFD.AFDRegistro2.Campo07 = Linha.Substring(37, 12);
                        pontoAFD.AFDRegistro2.Campo08 = Linha.Substring(49, 150);
                        pontoAFD.AFDRegistro2.Campo09 = Linha.Substring(199, Linha.Length - 199);
                    }

                    // Registro 3
                    if (Linha.Substring(9, 1) == "3")
                    {
                        AFD_Registro3 registro3 = new AFD_Registro3();

                        registro3.Campo01 = Linha.Substring(0, 9);
                        registro3.Campo02 = Linha.Substring(9, 1);
                        registro3.Campo03 = Linha.Substring(10, 8);
                        registro3.Campo04 = Linha.Substring(18, 4);
                        registro3.Campo05 = Linha.Substring(22, Linha.Length - 22);

                        pontoAFD.ListaAFDRegistro3.Add(registro3);
                    }
                    
                    // Registro 4
                    if (Linha.Substring(9, 1) == "4")
                    {
                        AFD_Registro4 registro4 = new AFD_Registro4();

                        registro4.Campo01 = Linha.Substring(0, 9);
                        registro4.Campo02 = Linha.Substring(9, 1);
                        registro4.Campo03 = Linha.Substring(10, 8);
                        registro4.Campo04 = Linha.Substring(18, 4);
                        registro4.Campo05 = Linha.Substring(22, 8);
                        registro4.Campo06 = Linha.Substring(30, Linha.Length - 30);

                        pontoAFD.ListaAFDRegistro4.Add(registro4);
                    }

                    // Registro 5
                    if (Linha.Substring(9, 1) == "5")
                    {
                        AFD_Registro5 registro5 = new AFD_Registro5();

                        registro5.Campo01 = Linha.Substring(0, 9);
                        registro5.Campo02 = Linha.Substring(8, 1);
                        registro5.Campo03 = Linha.Substring(10, 8);
                        registro5.Campo04 = Linha.Substring(18, 4);
                        registro5.Campo05 = Linha.Substring(22, 1);
                        registro5.Campo06 = Linha.Substring(23, 12);
                        registro5.Campo07 = Linha.Substring(34, Linha.Length - 34);

                        pontoAFD.ListaAFDRegistro5.Add(registro5);
                    }

                    // Trailer
                    if (Linha.Substring(0, 1) == "9")
                    {
                        pontoAFD.AFDTrailer.Campo01 = Linha.Substring(0, 9);
                        pontoAFD.AFDTrailer.Campo02 = Linha.Substring(9, 9);
                        pontoAFD.AFDTrailer.Campo03 = Linha.Substring(18, 9);
                        pontoAFD.AFDTrailer.Campo04 = Linha.Substring(27, 9);
                        pontoAFD.AFDTrailer.Campo05 = Linha.Substring(36, 9);
                        pontoAFD.AFDTrailer.Campo06 = Linha.Substring(45, Linha.Length - 45);
                    }
                }
                objReader.Close();

            }
            catch (Exception eError)
            {
                MessageBox.Show("Ocorreu um erro: " + eError.Message);
            }

        }

    }
}
