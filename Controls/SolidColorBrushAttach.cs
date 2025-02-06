using System.Windows;

namespace NewLeaf.Controls
{
    public class SolidColorBrushAttach
    {
        public static readonly DependencyProperty ConvertProperty =
            DependencyProperty.RegisterAttached("Convert", typeof(string), typeof(SolidColorBrushAttach), new PropertyMetadata("Default Value"));

        public static string GetConvert(DependencyObject obj)
        {
            return (string)obj.GetValue(ConvertProperty);
        }

        public static void SetConvert(DependencyObject obj, string value)
        {
            obj.SetValue(ConvertProperty, value);
        }
    }
}
