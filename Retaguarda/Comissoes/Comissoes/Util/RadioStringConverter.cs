using System;
using System.Globalization;
using System.Windows.Data;

namespace Cadastros.Util
{
    public class RadioStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valor = value.ToString();
            if (valor == parameter.ToString())
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }

    }
}
