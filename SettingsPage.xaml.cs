using NewLeaf.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = Application.Current.Properties["Settings"] as SettingsViewModel;
        }
    }
}
