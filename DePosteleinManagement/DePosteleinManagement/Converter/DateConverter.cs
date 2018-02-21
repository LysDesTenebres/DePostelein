using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DePosteleinManagement.Converter
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            System.DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            if (value.ToString().Length == 13)
            {
                date = date.AddMilliseconds((long)value);
            }
            else
            {
                date = date.AddSeconds((long)value);
            }

            if (date == null)
            {
                return "";
            }
            else
            {
                return date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
