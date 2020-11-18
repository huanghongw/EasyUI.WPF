using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace EasyUI.WPF.Converter
{
    public class NotNullToVisiblity : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isInverseString;
            if (value == null)
            {
                return Visibility.Visible;
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
