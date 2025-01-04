using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafControl.xaml
    /// </summary>
    public partial class LeafControl : UserControl
    {
        public readonly DatabaseEntry DatabaseEntry;
        private readonly DatabaseHelper DatabaseHelper;
        private LeafWindow LeafWindow = null;

        public LeafControl(DatabaseEntry databaseEntry, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            DatabaseEntry = databaseEntry;
            DataContext = databaseEntry;
            DatabaseHelper = databaseHelper;
            LeafBorder.Background = new SolidColorBrush(databaseEntry.LeafColor);
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LeafWindow == null || !LeafWindow.IsLoaded)
            {
                LeafWindow = new LeafWindow(DatabaseEntry, DatabaseHelper);
                LeafWindow.Show();
            }
            else
            {
                LeafWindow.Activate();
                //leafWindow.Focus();
            }
        }
    }
}
