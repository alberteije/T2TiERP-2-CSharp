using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;

namespace ComponenteFolha
{
    public class ComponenteFolha
    {

        public static int NSR;

        public FolhaSefipRegistroTipo00 SefipRegistroTipo00 { get; set; }
        public FolhaSefipRegistroTipo10 SefipRegistroTipo10 { get; set; }
        public List<FolhaSefipRegistroTipo30> ListaSefipRegistroTipo30 = new List<FolhaSefipRegistroTipo30>();
        public FolhaSefipRegistroTipo90 SefipRegistroTipo90 { get; set; }

        public FolhaCagedRegistroTipoA CagedRegistroTipoA { get; set; }
        public FolhaCagedRegistroTipoB CagedRegistroTipoB { get; set; }
        public List<FolhaCagedRegistroTipoC> ListaCagedRegistroTipoC = new List<FolhaCagedRegistroTipoC>();

        public ComponenteFolha()
        {
            NSR = 0;  
        }

        public void gerarArquivoSefip(string salvarEm)
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine(SefipRegistroTipo00.gerarLinhaTexto());
            sb.AppendLine(SefipRegistroTipo10.gerarLinhaTexto());

            foreach (FolhaSefipRegistroTipo30 RegistroTipo30 in ListaSefipRegistroTipo30)
            {
                sb.AppendLine(RegistroTipo30.gerarLinhaTexto());
            }

            sb.AppendLine(SefipRegistroTipo90.gerarLinhaTexto());
            
            TextWriter tw = new StreamWriter(salvarEm);
            tw.Write(sb.ToString());
            tw.Close();

            if (File.Exists(salvarEm))
                Process.Start(salvarEm);
        }

        public void gerarArquivoCaged(string salvarEm)
        {
            StringBuilder sb = new StringBuilder("");

            sb.AppendLine(CagedRegistroTipoA.gerarLinhaTexto());
            sb.AppendLine(CagedRegistroTipoB.gerarLinhaTexto());

            foreach (FolhaCagedRegistroTipoC RegistroTipoB in ListaCagedRegistroTipoC)
            {
                sb.AppendLine(RegistroTipoB.gerarLinhaTexto());
            }

            TextWriter tw = new StreamWriter(salvarEm);
            tw.Write(sb.ToString());
            tw.Close();

            if (File.Exists(salvarEm))
                Process.Start(salvarEm);
        }


    }
}
