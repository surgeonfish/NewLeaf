﻿using System;
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
        private readonly DatabaseEntry DatabaseEntry;
        private readonly DatabaseHelper DatabaseHelper;

        public LeafWindow(DatabaseEntry databaseEntry, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            DatabaseEntry = databaseEntry;
            DatabaseHelper = databaseHelper;
            DataContext = databaseEntry;

            TittleBar.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            };

            SaveLeafButton.Click += (s, e) =>
            {
                //TextRange textRange = new TextRange(
                //    TextEditor.Document.ContentStart,
                //    TextEditor.Document.ContentEnd);
                //DatabaseEntry.Content = textRange.Text;
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                var textBox = (TextBox)sender;
                DatabaseHelper.UpdateEntry(DatabaseEntry.Id, DatabaseEntry.Date, textBox.Text);
            }
        }
    }
}
