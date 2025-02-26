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
using 设备管理系统.Models;
using 设备管理系统.ViewModels;

namespace 设备管理系统.Views
{
    /// <summary>
    /// UpdatePersonView.xaml 的交互逻辑
    /// </summary>
    public partial class UpdatePersonView : UserControl
    {
        public UpdatePersonView(Person person)
        {
            InitializeComponent();

            var vm = DataContext as UpdatePersonViewModel;
            vm.Person = person;
        }
    }
}
