using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace NewLeaf
{
    public class ThemeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string color)
            {
                if (parameter is string component)
                {
                    string componentColor = component + color;
                    // For a tittle, it could be the one of the following keys:
                    //     - "TittleYellow"
                    //     - "TittleGreen"
                    //     - "TittlePink"
                    //     - "TittlePurple"
                    //     - "TittleBlue"
                    //     - "TittleGray"
                    //     - "TittleCarbon"
                    //
                    // For a content, it could be the one of the following keys:
                    //     - "ContentYellow"
                    //     - "ContentGreen"
                    //     - "ContentPink"
                    //     - "ContentPurple"
                    //     - "ContentBlue"
                    //     - "ContentGray"
                    //     - "ContentCarbon"
                    //
                    // For a content, it could be the one of the following keys:
                    //     - "ContentYellow"
                    //     - "ContentGreen"
                    //     - "ContentPink"
                    //     - "ContentPurple"
                    //     - "ContentBlue"
                    //     - "ContentGray"
                    //     - "ContentCarbon"
                    if (Application.Current.Resources.Contains(componentColor))
                    {
                        return (Color)Application.Current.Resources[componentColor];
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
