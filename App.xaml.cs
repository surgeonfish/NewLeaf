using NewLeaf.Model;
using NewLeaf.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DatabaseHelper DatabaseHelper;
        private ObservableCollection<LeafControl> LeafControls;

        App()
        {
            InitializeComponent();
            DatabaseHelper = new DatabaseHelper("NewLeaf.db");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SettingsViewModel settingsViewModel = new SettingsViewModel();
            OnSwitchTheme(settingsViewModel.Theme);
            Properties["Settings"] = settingsViewModel;

            LeafControls = new ObservableCollection<LeafControl>();
            DatabaseHelper.GetAllLeaves((leaflViewModel) =>
            {
                LeafControl leafControl = new LeafControl(leaflViewModel);
                LeafControls.Add(leafControl);
                return 0;
            });
            Properties["LeafControls"] = LeafControls;
        }

        public void OnAddLeaf()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string content = "";
            string color = "Yellow";
            if (LeafControls.Count > 0)
            {
                // Default to the color of the last leaf.
                LeafControl lastLeafControl = LeafControls.Last();
                LeaflViewModel lastLeafViewModel = lastLeafControl.DataContext as LeaflViewModel;
                color = lastLeafViewModel.Color;
            }

            long lastId = DatabaseHelper.InsertLeaf(date, content, color);
            LeaflViewModel leaflViewModel = DatabaseHelper.GetLeaf(lastId);
            LeafControl leafControl = new LeafControl(leaflViewModel);
            LeafControls.Add(leafControl);
        }

        public void OnDeleteLeaf(int id)
        {
            // Delete it from the database
            DatabaseHelper.DeleteLeaf(id);

            // Delete it from the controls
            foreach (LeafControl leafControl in LeafControls)
            {
                LeaflViewModel leaflViewModel = leafControl.DataContext as LeaflViewModel;
                if (leaflViewModel.Id == id)
                {
                    LeafControls.Remove(leafControl);
                    break;
                }
            }
        }

        public void OnSwitchTheme(string theme)
        {
            String themeSource = "Themes/" + theme + ".xaml";
            ResourceDictionary resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/" + themeSource)
            };
            if (resourceDictionary != null)
            {
                Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }
    }
}
