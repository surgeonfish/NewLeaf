using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafWindow.xaml
    /// </summary>
    public partial class LeafWindow : Window
    {
        private readonly DatabaseEntry DatabaseEntry;
        private readonly DatabaseHelper DatabaseHelper;

        public LeafWindow(DatabaseEntry databaseEntry, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            DatabaseEntry = databaseEntry;
            DatabaseHelper = databaseHelper;
            DataContext = databaseEntry;

            TitleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };

            SaveLeafButton.Click += (s, e) =>
            {
                DatabaseEntry.LeafContent = TextEditor.Text;
                DatabaseHelper.UpdateEntry(DatabaseEntry);
            };

            ColorPickerButton.Click += (s, e) =>
            {
                if (ColorPicker.Visibility == Visibility.Collapsed)
                {
                    ColorPicker.Visibility = Visibility.Visible;
                }
            };

            ColorPicker.SetViewModel(DatabaseEntry, DatabaseHelper);

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
                DatabaseEntry.LeafContent = textBox.Text;
                DatabaseHelper.UpdateEntry(DatabaseEntry);
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
