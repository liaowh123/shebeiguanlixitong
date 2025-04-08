using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace 设备管理系统.Views
{
    /// <summary>
    /// InsertSpareView.xaml 的交互逻辑
    /// </summary>
    public partial class InsertSpareView : UserControl
    {
        public InsertSpareView(string title = "")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(title))
            {
                label.Content = title;
            }
        }
    }
}
