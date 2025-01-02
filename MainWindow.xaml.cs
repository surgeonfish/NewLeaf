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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseHelper databaseHelper;

        public MainWindow()
        {
            InitializeComponent();

            databaseHelper = new DatabaseHelper("test.db");

            SetTittleBar();
            LoadLeaves();
        }

        private void SetTittleBar()
        {
            TittleBar.MouseMove += (s, e) =>
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
                databaseHelper.InsertEntry(date, content);
                // Reload leaves if the database is updated.
                LoadLeaves();
            };

            MinimizeButton.Click += (s, e) =>
            {
                WindowState = WindowState.Minimized;
            };

            MaximizeButton.Click += (s, e) =>
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }

        private void LoadLeaves()
        {
            List<DatabaseEntry> entries = databaseHelper.GetAllEntries();

            Leaves.Children.Clear();
            foreach (DatabaseEntry entry in entries)
            {
                LeafControl leaf = new LeafControl(entry, databaseHelper);
                Leaves.Children.Add(leaf);
            }
        }
    }
}
