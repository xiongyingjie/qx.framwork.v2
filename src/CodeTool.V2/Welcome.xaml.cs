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

namespace CodeTool.V2
{
    /// <summary>
    /// Welcome.xaml 的交互逻辑
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (rbt_form.IsChecked != null && rbt_form.IsChecked.Value)
            {
                var w=new MainWindow();
                w.Show();
                MessageBox.Show("form");
            }else if(rbt_report.IsChecked != null && rbt_report.IsChecked.Value)
            {
                var w = new MainWindow();
                w.Show();
                MessageBox.Show("report");
            }
            else 
            {
                var w = new MainWindow();
                w.Show();
                MessageBox.Show("project");
            }
        }
        private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
        {
          Close();
           
        }
    }
}
