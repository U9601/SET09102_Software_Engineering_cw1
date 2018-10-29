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
    /// Interaction logic for MentionsList.xaml
    /// </summary>
    public partial class MentionsListWindow : Window
    {
        public MentionsListWindow()
        {
            InitializeComponent();
            datagrid();
        }
        public void datagrid()
        {
            dataGrid.ItemsSource = MethodsList.getDataMentionsList();
        }//end data grid
    }
}
