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

namespace Software_Engineering_cw1
{
    /// <summary>
    /// Interaction logic for ListsWindow.xaml
    /// </summary>
    public partial class ListsWindow : Window
    {
        public ListsWindow()
        {
            InitializeComponent();
        }

        private void sirListbutton_Click(object sender, RoutedEventArgs e)
        {
            SirListDisplay newWin = new SirListDisplay();
            newWin.Show();

        }

        private void trendingButton_Click(object sender, RoutedEventArgs e)
        {
            TrendingListWindow newWin = new TrendingListWindow();
            newWin.Show();
        }

        private void mentionsListButton_Click(object sender, RoutedEventArgs e)
        {
            MentionsListWindow newWin = new MentionsListWindow();
            newWin.Show();
        }
    }
}
