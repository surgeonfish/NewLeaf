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
        public LeafWindow(LeaflViewModel leaflViewModel)
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
                ((App)Application.Current).OnDeleteLeaf(leaflViewModel.Id);
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                if (sender is TextBox textBox)
                {
                    LeaflViewModel leaflViewModel = DataContext as LeaflViewModel;
                    leaflViewModel.Content = textBox.Text;
                }
            }
        }
    }
}
