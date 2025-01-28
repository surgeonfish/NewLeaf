using NewLeaf.Model;
using NewLeaf.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseHelper databaseHelper;

        public ObservableCollection<LeafControl> LeafControls { get; set; }

        public MainWindow()
        {
            LeafControls = new ObservableCollection<LeafControl>();

            InitializeComponent();

            databaseHelper = new DatabaseHelper("test.db");

            SetTitleBar();
            LoadLeaves();
        }

        private void SetTitleBar()
        {
            TitleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };

            NewLeafButton.Click += (s, e) =>
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string content = "";
                string color = "Yellow";
                if (Leaves.Items.Count > 0)
                {
                    // Default to the color of the last leaf.
                    LeafControl lastLeafControl = Leaves.Items[Leaves.Items.Count - 1] as LeafControl;
                    LeaflViewModel lastLeafViewModel = lastLeafControl.DataContext as LeaflViewModel;
                    color = lastLeafViewModel.Color;
                }

                long lastId = databaseHelper.InsertLeaf(date, content, color);
                LeaflViewModel leaflViewModel = databaseHelper.GetLeaf(lastId);
                LeafControl leafControl = new LeafControl(this, leaflViewModel);
                LeafControls.Add(leafControl);
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }

        private void LoadLeaves()
        {
            databaseHelper.GetAllLeaves((leaflViewModel) =>
            {
                LeafControl leafControl = new LeafControl(this, leaflViewModel);
                LeafControls.Add(leafControl);
                return 0;
            });
        }

        public void DeleteLeaf(LeafControl leafControl)
        {
            LeaflViewModel leaflViewModel = leafControl.DataContext as LeaflViewModel;
            databaseHelper.DeleteLeaf(leaflViewModel.Id);
            LeafControls.Remove(leafControl);
        }
    }
}
