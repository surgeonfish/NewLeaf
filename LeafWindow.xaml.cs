using NewLeaf.Model;
using NewLeaf.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafWindow.xaml
    /// </summary>
    public partial class LeafWindow : Window
    {
        public LeafWindow(MainWindow mainWindow, LeafControl leafControl, LeaflViewModel leaflViewModel)
        {
            InitializeComponent();
            DataContext = leaflViewModel;

            TitleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };

            SaveLeafButton.Click += (s, e) =>
            {
            };

            ColorPickerButton.Click += (s, e) =>
            {
                if (ColorPicker.Visibility == Visibility.Collapsed)
                {
                    ColorPicker.Visibility = Visibility.Visible;
                }
            };

            ColorPicker.SetViewModel(DataContext as LeaflViewModel);

            PinButton.Click += (s, e) =>
            {
                var toggleButton = (ToggleButton)s;
                if (toggleButton.IsChecked == true)
                {
                    Topmost = true;
                } else
                {
                    Topmost= false;
                }
            };

            DeleteLeafButton.Click += (s, e) =>
            {
                Close();
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var textBox = (TextBox)sender;
            }
        }

        private void ColorPicker_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ColorPicker.Visibility == Visibility.Visible)
            {
                ColorPicker.Visibility = Visibility.Collapsed;
            }
        }
    }
}
