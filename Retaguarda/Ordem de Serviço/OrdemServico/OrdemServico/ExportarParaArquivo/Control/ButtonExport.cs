using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Collections;

namespace ExportarParaArquivo.Control
{
    public class ButtonExport : Button
    {
        public static readonly DependencyProperty ExportDataGridSourceProperty =
          DependencyProperty.Register("ExportDataGridSource", typeof(Object),
          typeof(ButtonExport));

        public static readonly DependencyProperty ExportFileFormatProperty =
            DependencyProperty.Register("ExportFileFormat", typeof(Formato), typeof(ButtonExport));

        public Formato ExportFileFormat
        {
            get 
            {
                return (Formato) GetValue(ExportFileFormatProperty);
            }
            set 
            {
                SetValue(ExportFileFormatProperty, value);
            }

        }

        public Object ExportDataGridSource
        {
            get
            {
                return GetValue(ExportDataGridSourceProperty);
            }
            set
            {
                SetValue(ExportDataGridSourceProperty, value);
            }
        }
    }
}
