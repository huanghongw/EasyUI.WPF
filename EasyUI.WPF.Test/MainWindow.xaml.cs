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

namespace EasyUI.WPF.Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List< aaaa> a = new List<aaaa>()
            {
                new aaaa(){ Key="a",Value="av"},
                new aaaa(){ Key="b",Value="bv"},
                new aaaa(){ Key="c",Value="cv"}
                 
            };
            aaa.OriginalSource = a;
            aaa.DisplayMemberPath = "Key";
        }

        public class aaaa
        {
            public string Key { get; set; }

            public string Value { get; set; }
        }
    }
}
