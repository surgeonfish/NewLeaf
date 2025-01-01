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
using System.Windows.Shapes;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for LeafWindow.xaml
    /// </summary>
    public partial class LeafWindow : Window
    {
        private int Id;
        private string Date;
        private string Content;
        private DatabaseHelper DatabaseHelper;
        public LeafWindow(int id, string date, string content, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            TittleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };

            SaveLeafButton.Click += (s, e) =>
            {
                TextRange textRange = new TextRange(
                    TextEditor.Document.ContentStart,
                    TextEditor.Document.ContentEnd);
                DatabaseHelper.UpdateEntry(Id, Date, textRange.Text);
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

            Id = id;
            Date = date;
            Content = content;
            TextEditor.AppendText(Content);
            DatabaseHelper = databaseHelper;
        }
    }
}
