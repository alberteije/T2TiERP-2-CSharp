using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using Net.Sgoliver.NRtfTree.Util;

namespace ExportarParaArquivo.Exportador
{
    class ExportadorRTF:IExportador
    {
        public void Exportar(System.Windows.Controls.DataGrid dg)
        {
            try
            {
                List<Object> itens = new List<object>((IEnumerable<object>)dg.ItemsSource);

                if (itens != null && itens.Count > 0)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "dadosLista";
                    dlg.DefaultExt = ".rtf";
                    dlg.Filter = "Arquivo RTF (.rtf)|*.rtf";

                    Nullable<bool> result = dlg.ShowDialog();

                    if (result == true)
                    {
                        FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.ReadWrite);
                        fs.Close();

                        RtfDocument rtfDoc = new RtfDocument(dlg.FileName);

                        StringBuilder sb = new StringBuilder();

                        foreach (DataGridColumn coluna in dg.Columns)
                        {
                            sb.Append(coluna.Header.ToString());
                            sb.Append("\t");
                        }
                        RtfCharFormat rtfCharFormat = new RtfCharFormat();
                        rtfCharFormat.Bold = true;
                        rtfCharFormat.Size = 14;

                        rtfDoc.AddText(sb.ToString(), rtfCharFormat);
                        rtfDoc.AddNewLine();
                        rtfDoc.ResetCharFormat();
                        sb.Clear();

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
                                sb.Append(conteudo);
                                sb.Append("\t");
                            }
                            rtfDoc.AddText(sb.ToString());
                            rtfDoc.AddNewLine();
                            sb.Clear();
                        }
                        rtfDoc.Close();
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
