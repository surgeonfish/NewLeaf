using System;
using System.Globalization;
using System.Windows.Data;

namespace NewLeaf.Controls
{
    public class ThemeSelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string theme && parameter is string name)
            {
                return theme == name;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && parameter is string name)
            {
                if (isChecked)
                {
                    return name;
                }
            }
            return Binding.DoNothing;
        }
    }
}
