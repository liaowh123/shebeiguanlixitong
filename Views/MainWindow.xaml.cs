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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //role = 0 表示管理员
            if (AppData.Instance.CurrentUser.Role == 0)
            {
                IndexView.IsChecked = true;
                //container.Content = new IndexView();
            }
            else
            {
                IndexStudentView.IsChecked = true;
                //container.Content = new IndexStudentView();
            }

            Marker.Instance.Init(marker);

        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button != null)
            {
                try
                {
                    Type type = Type.GetType($"设备管理系统.Views.{button.Name}");
                    var view = Activator.CreateInstance(type);
                    container.Content = view;
                }
                catch (Exception ex)
                {
                    new Views.MessageBox(ex.Message).ShowDialog();
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                // 确保窗口不会覆盖任务栏
                MaxHeight = SystemParameters.WorkArea.Height;
                MaxWidth = SystemParameters.WorkArea.Width;
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            // 初始设置最大高度不超过工作区域
            MaxHeight = SystemParameters.WorkArea.Height;
            MaxWidth = SystemParameters.WorkArea.Width;
        }
    }
}
