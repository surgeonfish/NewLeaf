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
        private DatabaseEntry DatabaseEntry;
        private DatabaseHelper DatabaseHelper;
        public ColorPicker()
        {
            InitializeComponent();
        }

        public void SetViewModel(DatabaseEntry databaseEntry, DatabaseHelper databaseHelper)
        {
            DatabaseEntry = databaseEntry;
            DatabaseHelper = databaseHelper;

            foreach (ToggleButton button in ColorPalette.Children)
            {
                if (button.Name == DatabaseEntry.LeafColor)
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

                DatabaseEntry.LeafColor = toggleButton.Name;
                DatabaseHelper.UpdateEntry(DatabaseEntry);
            }
        }
    }
}
