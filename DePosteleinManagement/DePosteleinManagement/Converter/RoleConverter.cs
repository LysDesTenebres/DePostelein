using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DePosteleinManagement.Converter
{
    public class RoleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String convert = value.ToString();
            String[] split = convert.Split('_');
            String returnValue = split[1].ToLower();
            char[] a = returnValue.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
