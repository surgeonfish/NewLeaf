using System;
using System.Collections.Generic;
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
                    // Default to the color of the first leaf.
                    LeafControl leafControl = Leaves.Items[Leaves.Items.Count - 1] as LeafControl;
                    color = leafControl.DatabaseEntry.LeafColor;
                }
                databaseHelper.InsertEntry(date, content, color);

                DatabaseEntry entry = new DatabaseEntry()
                {
                    LeafContent = content,
                    LeafColor = color,
                    DateCreated = date,
                    DateLastUpdated = date,
                };
                LeafControl leaf = new LeafControl(entry, databaseHelper);
                LeafControls.Add(leaf);
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
            foreach (DatabaseEntry entry in entries)
            {
                LeafControl leaf = new LeafControl(entry, databaseHelper);
                LeafControls.Add(leaf);
            }
        }
    }
}
