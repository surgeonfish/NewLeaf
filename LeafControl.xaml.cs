using NewLeaf.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafControl.xaml
    /// </summary>
    public partial class LeafControl : UserControl
    {
        private readonly MainWindow MainWindow = null;
        private LeafWindow LeafWindow = null;

        public LeafControl(MainWindow mainWindow, LeaflViewModel leaflViewModel)
        {
            InitializeComponent();
            DataContext = leaflViewModel;
            MainWindow = mainWindow;
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LeafWindow == null || !LeafWindow.IsLoaded)
            {
                LeafWindow = new LeafWindow(MainWindow, this, DataContext as LeaflViewModel);
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
