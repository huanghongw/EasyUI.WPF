using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasyUI.WPF.Converter
{
    public class ParamWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double apr = 1;
            if (parameter == null)
            {

            }
            else
            {
                double.TryParse(parameter.ToString(), out apr);
            }
            var isInverse = int.Parse(value.ToString());
            return int.Parse(Math.Round(isInverse * apr, 0).ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
