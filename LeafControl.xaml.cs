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
    /// Interaction logic for LeafControl.xaml
    /// </summary>
    public partial class LeafControl : UserControl
    {
        private int Id;
        private string Date;
        private string Content;
        private DatabaseHelper DatabaseHelper;
        private LeafWindow leafWindow = null;
        public LeafControl(int id, string date, string content, DatabaseHelper databaseHelper)
        {
            InitializeComponent();
            Id = id;
            Date = date;
            Content = content;

            DateText.Text = date;
            ContentText.Text = content;
            DatabaseHelper = databaseHelper;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (leafWindow == null)
            {
                leafWindow = new LeafWindow(Id, Date, Content, DatabaseHelper);
                leafWindow.Show();
            }
            else
            {
                leafWindow.Activate();
                //leafWindow.Focus();
            }
        }
    }
}
