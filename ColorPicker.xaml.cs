using NewLeaf.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        public void SetViewModel(LeaflViewModel leaflViewModel)
        {
            DataContext = leaflViewModel;

            foreach (ToggleButton button in ColorPalette.Children)
            {
                if (button.Name == leaflViewModel.Color)
                {
                    button.IsChecked = true;
                }
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
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
    }
}
