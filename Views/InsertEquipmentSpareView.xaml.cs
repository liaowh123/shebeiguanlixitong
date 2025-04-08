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
    /// InsertEquipmentSpareView.xaml 的交互逻辑
    /// </summary>
    public partial class InsertEquipmentSpareView : UserControl
    {
       
        public InsertEquipmentSpareView(List<Equipment> equipments,string title = "" )
        {
            InitializeComponent();

            
            if (!string.IsNullOrEmpty(title))
            {
                label.Content = title;
            }
            //comboBox.ItemsSource = equipments;
            var vm = DataContext as InsertEquipmentSpareViewModel;
            if (vm != null)
            {
                vm.Equipments = equipments;
                //vm.HashSet1();
            }

        }

        public InsertEquipmentSpareView(List<Equipment> equipments, EquipmentSpare equipmentSpare, string title = "")
        {
            InitializeComponent();


            if (!string.IsNullOrEmpty(title))
            {
                label.Content = title;
            }
            //comboBox.ItemsSource = equipments;
            var vm = DataContext as InsertEquipmentSpareViewModel;
            if (vm != null)
            {
                vm.Equipments = equipments;
                vm.EquipmentSpare = equipmentSpare;
                //vm.HashSet1();
            }

        }

    }
}
