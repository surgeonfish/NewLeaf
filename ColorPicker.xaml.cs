using NewLeaf.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// ColorPicker.xaml 的交互逻辑
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton toggleButton && toggleButton.IsChecked == true)
            {
                if (toggleButton.Parent is Grid grid)
                {
                    foreach (ToggleButton button in grid.Children)
                    {
                        if (button != toggleButton && button.IsChecked == true)
                        {
                            button.IsChecked = false;
                        }
                    }
                }

                LeaflViewModel leaflViewModel = DataContext as LeaflViewModel;
                leaflViewModel.Color = toggleButton.Name;
            }
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var toggleButton = sender as ToggleButton;
            if (toggleButton.IsChecked.HasValue && toggleButton.IsChecked.Value)
            {
                e.Handled = true;
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Visibility = Visibility.Collapsed;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LeaflViewModel leaflViewModel = DataContext as LeaflViewModel;
            foreach (ToggleButton toggleButton in ColorPalette.Children)
            {
                if (toggleButton.Name == leaflViewModel.Color)
                {
                    toggleButton.IsChecked = true;
                }
            }
        }
    }
}
