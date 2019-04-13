using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using System.IO;
using NPOI.SS.UserModel;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Collections;
using System.Windows.Data;

namespace ExportarParaArquivo.Exportador
{
    class ExportadorExcel : IExportador
    {
        private List<Object> itens;

        public void Exportar(DataGrid dg)
        {
            try
            {
                itens = new List<object>((IEnumerable<object>)dg.ItemsSource);

                if (itens != null && itens.Count > 0)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "dadosLista";
                    dlg.DefaultExt = ".xls";
                    dlg.Filter = "XLS documents (.xls)|*.xls";

                    Nullable<bool> result = dlg.ShowDialog();

                    if (result == true)
                    {
                        FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.ReadWrite);
                        HSSFWorkbook workbook1 = new HSSFWorkbook();
                        Sheet planilha = workbook1.CreateSheet("default");

                        for (int i = 0; i < itens.Count + 1; i++)
                            planilha.CreateRow(i);

                        int indexColuna = 0;

                        foreach (DataGridColumn coluna in dg.Columns)
                        {
                            Binding binding = (Binding)((DataGridBoundColumn)coluna).Binding;
                            string path = binding.Path.Path;
                            planilha.GetRow(0).CreateCell(indexColuna).SetCellValue(coluna.Header.ToString());

                            string[] hierarquiaObj = path.Split('.');

                            int indexLinhas = 1;
                            dynamic conteudo = "";
                            foreach (Object item in itens)
                            {
                                Object itemAux = item;
                                for (int i = 0; i < hierarquiaObj.Length - 1; i++)
                                {
                                    itemAux = itemAux.GetType().GetProperty(hierarquiaObj[i]).GetValue(itemAux, null);
                                }
                                string prop = hierarquiaObj[hierarquiaObj.Length - 1];
                                conteudo = itemAux.GetType().GetProperty(prop).GetValue(itemAux, null).ToString();
                                planilha.GetRow(indexLinhas).CreateCell(indexColuna).SetCellValue(conteudo);
                                indexLinhas++;
                            }
                            indexColuna++;
                        }
                        fs.Write(workbook1.GetBytes(), 0, workbook1.GetBytes().Length);
                        fs.Flush();
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
