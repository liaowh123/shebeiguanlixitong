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
using 设备管理系统.Helper;

namespace 设备管理系统.Views
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : Window
    {
        public bool IsOk { get; set; } = false;
        public MessageBox()
        {
            InitializeComponent();
            Loaded += MessageBox_Loaded;
            Closed += MessageBox_Closed;
        }

        public MessageBox(string message)
        {
            InitializeComponent();
            textblock.Text = message;
            Loaded += MessageBox_Loaded;
            Closed += MessageBox_Closed;
        }

        private void MessageBox_Closed(object sender, EventArgs e)
        {
            Marker.Instance.Hide();
        }

        private void MessageBox_Loaded(object sender, RoutedEventArgs e)
        {
            Marker.Instance.Show();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            IsOk = true;
            Close();
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
