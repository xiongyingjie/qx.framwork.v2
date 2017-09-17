using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CodeTool.V2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       
   
        public MainWindow()
        {
            InitializeComponent();
            cb_friut.Items.Clear();
            cb_friut.Items.Add("苹果2");
            cb_friut.Items.Add("梨子5");

            var list = new List<PersonIdIsString>() {
            new PersonIdIsString(){Id="1",Name="m",ParentId=null},
            new PersonIdIsString(){Id="2",Name="n",ParentId=null},
            new PersonIdIsString(){Id="3",Name="mm3",ParentId="1"},
            new PersonIdIsString(){Id="4",Name="mm4",ParentId="1"},
            new PersonIdIsString(){Id="5",Name="mm5",ParentId="1"},
            new PersonIdIsString(){Id="6",Name="mmm6",ParentId="5"},
            new PersonIdIsString(){Id="7",Name="mmm7",ParentId="5"},
            };

            commonTreeView1.SetItemsSourceData(list, p => p.Name, p => p.Id, p => p.ParentId);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           
         
          
            //var t = tv_report;
            MessageBox.Show("用户名"+tb_uid.Text);
            MessageBox.Show("密码" + tb_psw.Text);
        }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
       
    }
        public class PersonIdIsString
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ParentId { get; set; }
        }
    }
}
