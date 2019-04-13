using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace FluxoCaixaClient.Util
{
    public class BooleanCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            char valor = value != null ? (char)value : 'N' ;
            char param = ((string)parameter).ToCharArray()[0];
            if (valor == param)
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valor = (bool) value;
            if(valor)
                return ((string)parameter).ToCharArray()[0];
            return null;
        }

    }
}
