using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using 设备管理系统.BLL;
using 设备管理系统.Models;
using 学生成绩管理系统.Helper;
using 设备管理系统.MVVM;
using 设备管理系统.Views;

namespace 设备管理系统.ViewModels
{
    internal class EquipmentViewModel : ObservableObject
    {
        private EquipmentService equipmentService = new EquipmentService();
        private List<Equipment> equipments = new List<Equipment>();
        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; RaisePropertyChanged(); }
        }
        public ICommand LoadedCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public EquipmentViewModel()
        {
            LoadedCommand = new DelegateCommand(OnLoadedCommand);
            InsertCommand = new DelegateCommand(OnInsertCommand);
            UpdateCommand = new DelegateCommand<Equipment>(OnUpdateCommand);
            DeleteCommand = new DelegateCommand<Equipment>(OnDeleteCommand);
        }

        private void OnDeleteCommand(Equipment equipment)
        {
            if (equipment == null)
                return;

            MessageBox messageBox = new MessageBox($"是否要删除{equipment.Name}?");
            messageBox.ShowDialog();
            if (messageBox.IsOk)
            {
                var count = equipmentService.Delete(equipment);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Equipments = equipmentService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }
            }
        }

        private void OnUpdateCommand(Equipment equipment)
        {
            if (equipment != null)
            {
                //做一份深拷贝
                var temp = CopyHelper.DeepCopy(equipment);
                UpdateEquipmentView view = new UpdateEquipmentView(temp);
                DialogWindow dialogWindow = new DialogWindow(view, "修改记录");//确定，取消的按钮界面
                dialogWindow.OnSubmit += (arg) =>
                {
                    var vm = arg as UpdateEquipmentViewModel;
                    equipment = vm.Equipment;
                    var count = equipmentService.Update(equipment);
                    if (count > 0)
                    {
                        new MessageBox($"操作成功").ShowDialog();
                        Equipments = equipmentService.GetAll();
                    }
                    else
                    {
                        new MessageBox($"操作失败").ShowDialog();
                    }
                };
                dialogWindow.ShowDialog();
            }
        }

        private void OnInsertCommand()
        {
            InsertEquipmentView insertEquipmentView = new InsertEquipmentView("请输入设备信息");
            DialogWindow dialogWindow = new DialogWindow(insertEquipmentView);
            dialogWindow.OnSubmit += (arg) =>
            {
                var vm = arg as InsertEquipmentViewModel;
                Equipment equipment = new Equipment();
                //equipment.Name = vm.Equipment.Name;
                equipment = vm.Equipment;
                var count = equipmentService.Insert(equipment);
                if (count > 0)
                {
                    new MessageBox($"操作成功").ShowDialog();
                    Equipments = equipmentService.GetAll();
                }
                else
                {
                    new MessageBox($"操作失败").ShowDialog();
                }

            };
            dialogWindow.ShowDialog();
        }

        private void OnLoadedCommand()
        {
            Equipments = equipmentService.GetAll();
        }
    }
}
