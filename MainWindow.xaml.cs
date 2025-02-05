using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewLeaf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTitleBar();
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

            NewAndBackButton.Click += (s, e) =>
            {
                if (NewAndBackButton.ToolTip is TextBlock textBlock)
                {
                    if (textBlock.Text == "New")
                    {
                        ((App)Application.Current).OnAddLeaf();
                    }
                    else if (textBlock.Text == "Back")
                    {
                        MainFrame.NavigationService.GoBack();
                        SettingsButton.Visibility = Visibility.Visible;
                    }
                }
            };

            SettingsButton.Click += (s, e) =>
            {
                MainFrame.NavigationService.Navigate(new Uri("pack://application:,,,/SettingsPage.xaml"));
                SettingsButton.Visibility = Visibility.Hidden;
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
