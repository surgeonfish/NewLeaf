using System.Windows.Controls;
using System.Windows.Input;

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
