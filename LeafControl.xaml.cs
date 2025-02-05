using NewLeaf.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafControl.xaml
    /// </summary>
    public partial class LeafControl : UserControl
    {
        private LeafWindow LeafWindow = null;

        public LeafControl(LeaflViewModel leaflViewModel)
        {
            InitializeComponent();
            DataContext = leaflViewModel;
        }

        private void OpenLeafWindow()
        {
            if (LeafWindow == null || !LeafWindow.IsLoaded)
            {
                LeafWindow = new LeafWindow(DataContext as LeaflViewModel);
                LeafWindow.Show();
            }
            else
            {
                LeafWindow.Activate();
                //leafWindow.Focus();
            }
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenLeafWindow();
        }

        private void OnOpenMenuClick(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenLeafWindow();
        }

        private void OnDeleteMenuClick(object sender, System.Windows.RoutedEventArgs e)
        {
            LeaflViewModel leaflViewModel = DataContext as LeaflViewModel;
            ((App)Application.Current).OnDeleteLeaf(leaflViewModel.Id);
        }
    }
}
