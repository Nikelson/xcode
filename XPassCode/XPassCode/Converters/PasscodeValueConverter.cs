using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XPassCode.Converters
{

    public class PasscodeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            string param = (string)parameter;

            int index = string.IsNullOrEmpty(param) ? 0 : int.Parse(param);

            if (string.IsNullOrEmpty(val) || val.Length <= index) {
                return "";
            }

            return val[index];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }
}
