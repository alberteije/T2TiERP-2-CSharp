using System;
using System.Globalization;
using System.Windows.Data;

namespace BalcaoPAF.Util
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
