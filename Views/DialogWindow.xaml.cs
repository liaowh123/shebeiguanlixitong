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
using 学生成绩管理系统.Helper;

namespace 设备管理系统.Views
{
    /// <summary>
    /// DialogWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DialogWindow : Window
    {
        public string Title { get; private set; }
        public UserControl UserControl { get; private set; }

        public event Action<object> OnSubmit;//确定时引发的事件
        public DialogWindow(UserControl userControl, string title = "对话框")
        {
            InitializeComponent();
            UserControl = userControl;
            Title = title;
            DialogWindow_Loaded();
            Closed += (s, e) => Marker.Instance.Hide();
        }

        private void DialogWindow_Loaded()
        {
            Marker.Instance.Show();

            buttonExit.Click += (s, args) => Close();
            buttonCancel.Click += (s, args) => Close();
            buttonOK.Click += (s, args) =>
            {
                OnSubmit?.Invoke(UserControl.DataContext);
                Close();
            };

            //init...
            if (UserControl == null)
            {
                return;
            }

            container.Content = UserControl;
            Height = UserControl.Height;
            Width = UserControl.Width;

            //居中显示
            Left = (SystemParameters.PrimaryScreenWidth / 2) - Width / 2;
            Top = (SystemParameters.PrimaryScreenHeight / 2) - Height / 2;
        }
    }
}
