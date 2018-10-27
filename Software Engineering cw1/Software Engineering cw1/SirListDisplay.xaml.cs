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

namespace Software_Engineering_cw1
{
    /// <summary>
    /// Interaction logic for SirListDisplay.xaml
    /// </summary>
    public partial class SirListDisplay : Window
    {
        public SirListDisplay()
        {
            InitializeComponent();
            datagrid();
        }

        public void datagrid()
        {
            dataGrid.ItemsSource = ReadingExcel.getData();
        }//end data grid
    }
}
