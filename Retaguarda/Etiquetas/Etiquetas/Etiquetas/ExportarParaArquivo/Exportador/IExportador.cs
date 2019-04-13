using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Collections;

namespace ExportarParaArquivo.Exportador
{
    interface IExportador
    {
        void Exportar(DataGrid dataGrid);
    }
}
