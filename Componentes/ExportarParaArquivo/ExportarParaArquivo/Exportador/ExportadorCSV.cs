using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Windows.Data;

namespace ExportarParaArquivo.Exportador
{
    class ExportadorCSV :IExportador
    {
        public void Exportar(DataGrid dg)
        {
            try
            {
                List<Object> itens = new List<object>((IEnumerable<object>)dg.ItemsSource);

                if (itens != null && itens.Count > 0)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "dadosLista";
                    dlg.DefaultExt = ".csv";
                    dlg.Filter = "Arquivo CSV (.csv)|*.csv";

                    Nullable<bool> result = dlg.ShowDialog();

                    if (result == true)
                    {
                        FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.ReadWrite);

                        StringBuilder sb = new StringBuilder();

                        foreach (DataGridColumn coluna in dg.Columns)
                        {
                            sb.Append("\"");
                            sb.Append(coluna.Header.ToString());
                            sb.Append("\"");
                            sb.Append(",");
                        }
                        sb.AppendLine();

                        foreach (Object item in itens)
                        {
                            foreach (DataGridColumn coluna in dg.Columns)
                            {
                                Binding binding = (Binding)((DataGridBoundColumn)coluna).Binding;
                                string path = binding.Path.Path;
                                string[] hierarquiaObj = path.Split('.');

                                Object itemAux = item;
                                for (int i = 0; i < hierarquiaObj.Length - 1; i++)
                                {
                                    itemAux = itemAux.GetType().GetProperty(hierarquiaObj[i]).GetValue(itemAux, null);
                                }

                                string prop = hierarquiaObj[hierarquiaObj.Length - 1];

                                string conteudo = itemAux.GetType().GetProperty(prop).
                                    GetValue(itemAux, null).ToString();

                                sb.Append("\"");
                                sb.Append(conteudo);
                                sb.Append("\"");
                                sb.Append(",");
                            }
                            sb.AppendLine();
                        }
                        fs.Write(System.Text.Encoding.Default.GetBytes(sb.ToString()), 0, 
                            sb.ToString().Length);
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
