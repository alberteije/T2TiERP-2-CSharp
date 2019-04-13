using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExportarParaArquivo.Exportador;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections;

namespace ExportarParaArquivo
{
    public enum Formato
    { 
        XLS, 
        CSV, 
        TXT, 
        RTF,
    }
    public class Exportar
    {
        private IExportador exportador;

        public Exportar(Formato formatoDestino)
        {
            if(formatoDestino.Equals(Formato.XLS))
                exportador = new ExportadorExcel();
            if (formatoDestino.Equals(Formato.CSV))
                exportador = new ExportadorCSV();
            if (formatoDestino.Equals(Formato.TXT))
                exportador = new ExportadorTXT();
            if (formatoDestino.Equals(Formato.RTF))
                exportador = new ExportadorRTF();
        }

        public void exportarDataGrid(DataGrid dg)
        {
            exportador.Exportar(dg);
        }

    }
}
