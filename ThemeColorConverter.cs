using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace NewLeaf
{
    public class ThemeColorConverter : IMultiValueConverter
    {
        public string Type { get; set; }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] is string color && value[1] is SolidColorBrush brush)
            {
                string componentColor = Type + color;
                // For a title, it could be the one of the following keys:
                //     - "TitleYellow"
                //     - "TitleGreen"
                //     - "TitlePink"
                //     - "TitlePurple"
                //     - "TitleBlue"
                //     - "TitleGray"
                //     - "TitleCarbon"
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
                // For a picker, it could be the one of the following keys:
                //     - "PickerYellow"
                //     - "PickerGreen"
                //     - "PickerPink"
                //     - "PickerPurple"
                //     - "PickerBlue"
                //     - "PickerGray"
                //     - "PickerCarbon"
                if (Application.Current.Resources.Contains(componentColor))
                {
                    DependencyProperty colorProperty = SolidColorBrush.ColorProperty;
                    DynamicResourceExtension dynamicResourceExtension = new DynamicResourceExtension(componentColor);
                    var resourceReferenceExpression = dynamicResourceExtension.ProvideValue(null);
                    brush.SetValue(colorProperty, resourceReferenceExpression);
                    return color;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
