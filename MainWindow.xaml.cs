using System.Windows;
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

            NewLeafButton.Click += (s, e) =>
            {
                ((App)Application.Current).OnAddLeaf();
            };

            CloseButton.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
