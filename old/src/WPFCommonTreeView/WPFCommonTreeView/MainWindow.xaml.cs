using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCommonTreeView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            var list = new List<PersonIdIsInt>() { 
            new PersonIdIsInt(){Id=1,Name="a",ParentId=0},
            new PersonIdIsInt(){Id=2,Name="b",ParentId=0},
            new PersonIdIsInt(){Id=3,Name="aa3",ParentId=1},
            new PersonIdIsInt(){Id=4,Name="aa4",ParentId=1},
            new PersonIdIsInt(){Id=5,Name="aa5",ParentId=1},
            new PersonIdIsInt(){Id=6,Name="aaa6",ParentId=5},
            new PersonIdIsInt(){Id=7,Name="aaa7",ParentId=5},
            };




            commonTreeView1.SetItemsSourceData(list, p => p.Name, p => p.Id, p => p.ParentId);
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
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
    }


    public class PersonIdIsInt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }


    public class PersonIdIsString
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
    }
}
